using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using QuizApp.Managers;
using QuizApp.Models;

namespace QuizApp.Forms.Admin
{
    public partial class UserManagementForm : UserControl
    {
        public UserManagementForm()
        {
            InitializeComponent();
        }

        private void UserManagementControl_Load(object sender, EventArgs e)
        {
            cmbFilter.SelectedIndex = 0;
            ReloadUserList();
        }

        // ==================== LOAD USERS ====================
        private void ReloadUserList()
        {
            lvUsers.BeginUpdate();
            lvUsers.Items.Clear();

            List<User> users = UserManager.Instance.Users;

            for (int i = 0; i < users.Count; i++)
            {
                User user = users[i];
                ListViewItem item = new ListViewItem(user.Id.ToString());
                item.SubItems.Add(user.Username);
                item.SubItems.Add(user.FullName);
                item.SubItems.Add(user.Email);
                item.SubItems.Add(user.Role.ToString());
                item.SubItems.Add(user.IsActive ? "Hoạt động" : "Bị khóa");
                item.SubItems.Add(user.CreatedDate.ToString("dd/MM/yyyy"));
                item.Tag = user;

                if (!user.IsActive)
                {
                    item.ForeColor = Color.Gray;
                }

                lvUsers.Items.Add(item);
            }

            UpdateStatistics();
            lvUsers.EndUpdate();
            lvUsers.Refresh();
            lvUsers.Invalidate();
        }

        private void UpdateStatistics()
        {
            int total = UserManager.Instance.Users.Count;
            int students = UserManager.Instance.GetUserCountByRole(UserRole.Student);
            int teachers = UserManager.Instance.GetUserCountByRole(UserRole.Teacher);
            int admins = UserManager.Instance.GetUserCountByRole(UserRole.Admin);

            lblStats.Text = string.Format("Tổng: {0} | Học sinh: {1} | Giáo viên: {2} | Admin: {3}",
                total, students, teachers, admins);
        }

        // ==================== BUTTON ADD ====================
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddUserForm addForm = new AddUserForm();
            DialogResult result = addForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                UserManager.Instance.SaveUsers();
                ReloadUserList();
                MessageBox.Show("Thêm người dùng thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ==================== BUTTON EDIT ====================
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (lvUsers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn người dùng cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            User selectedUser = (User)lvUsers.SelectedItems[0].Tag;

            EditUserForm editForm = new EditUserForm(selectedUser);
            DialogResult result = editForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                UserManager.Instance.SaveUsers();
                ReloadUserList();
                MessageBox.Show("Cập nhật thông tin thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ==================== BUTTON DELETE ====================
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (lvUsers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn người dùng cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            User selectedUser = (User)lvUsers.SelectedItems[0].Tag;

            if (selectedUser.Id == UserManager.Instance.CurrentUser.Id)
            {
                MessageBox.Show("Không thể xóa tài khoản đang đăng nhập!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string message = string.Format("Bạn có chắc muốn xóa người dùng '{0}'?", selectedUser.FullName);
            DialogResult result = MessageBox.Show(message, "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                bool success = UserManager.Instance.RemoveUser(selectedUser.Id);
                if (success)
                {
                    UserManager.Instance.SaveUsers();
                    ReloadUserList();
                    MessageBox.Show("Xóa người dùng thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không thể xóa người dùng!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==================== BUTTON TOGGLE STATUS ====================
        private void BtnToggleStatus_Click(object sender, EventArgs e)
        {
            if (lvUsers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn người dùng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            User selectedUser = (User)lvUsers.SelectedItems[0].Tag;

            if (selectedUser.Id == UserManager.Instance.CurrentUser.Id)
            {
                MessageBox.Show("Không thể khóa tài khoản đang đăng nhập!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string action = selectedUser.IsActive ? "khóa" : "mở khóa";
            string message = string.Format("Bạn có chắc muốn {0} người dùng '{1}'?", action, selectedUser.FullName);
            DialogResult result = MessageBox.Show(message, "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                bool success = UserManager.Instance.ToggleUserStatus(selectedUser.Id);
                if (success)
                {
                    UserManager.Instance.SaveUsers();
                    ReloadUserList();
                    string successMsg = string.Format("Đã {0} người dùng thành công!", action);
                    MessageBox.Show(successMsg, "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // ==================== BUTTON REFRESH ====================
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            UserManager.Instance.SaveUsers();
            ReloadUserList();
        }

        // ==================== SEARCH ====================
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            SearchUsers();
        }

        private void TxtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SearchUsers();
                e.Handled = true;
            }
        }

        private void SearchUsers()
        {
            string searchText = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                ReloadUserList();
                return;
            }

            lvUsers.BeginUpdate();
            lvUsers.Items.Clear();

            List<User> users = UserManager.Instance.Users;

            for (int i = 0; i < users.Count; i++)
            {
                User user = users[i];

                bool matchUsername = user.Username.ToLower().IndexOf(searchText) >= 0;
                bool matchFullName = user.FullName.ToLower().IndexOf(searchText) >= 0;
                bool matchEmail = user.Email.ToLower().IndexOf(searchText) >= 0;

                if (matchUsername || matchFullName || matchEmail)
                {
                    ListViewItem item = new ListViewItem(user.Id.ToString());
                    item.SubItems.Add(user.Username);
                    item.SubItems.Add(user.FullName);
                    item.SubItems.Add(user.Email);
                    item.SubItems.Add(user.Role.ToString());
                    item.SubItems.Add(user.IsActive ? "Hoạt động" : "Bị khóa");
                    item.SubItems.Add(user.CreatedDate.ToString("dd/MM/yyyy"));
                    item.Tag = user;

                    if (!user.IsActive)
                    {
                        item.ForeColor = Color.Gray;
                    }

                    lvUsers.Items.Add(item);
                }
            }

            lvUsers.EndUpdate();
            lvUsers.Refresh();
            lvUsers.Invalidate();
        }

        // ==================== FILTER ====================
        private void CmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterUsers();
        }

        private void FilterUsers()
        {
            if (cmbFilter.SelectedIndex == 0)
            {
                ReloadUserList();
                return;
            }

            lvUsers.BeginUpdate();
            lvUsers.Items.Clear();

            UserRole filterRole = UserRole.Student;
            bool filterByRole = false;
            bool filterByStatus = false;
            bool filterActiveValue = true;

            switch (cmbFilter.SelectedIndex)
            {
                case 1: filterRole = UserRole.Student; filterByRole = true; break;
                case 2: filterRole = UserRole.Teacher; filterByRole = true; break;
                case 3: filterRole = UserRole.Admin; filterByRole = true; break;
                case 4: filterByStatus = true; filterActiveValue = true; break;
                case 5: filterByStatus = true; filterActiveValue = false; break;
            }

            List<User> users = UserManager.Instance.Users;

            for (int i = 0; i < users.Count; i++)
            {
                User user = users[i];
                bool match = true;

                if (filterByRole && user.Role != filterRole) match = false;
                if (filterByStatus && user.IsActive != filterActiveValue) match = false;

                if (match)
                {
                    ListViewItem item = new ListViewItem(user.Id.ToString());
                    item.SubItems.Add(user.Username);
                    item.SubItems.Add(user.FullName);
                    item.SubItems.Add(user.Email);
                    item.SubItems.Add(user.Role.ToString());
                    item.SubItems.Add(user.IsActive ? "Hoạt động" : "Bị khóa");
                    item.SubItems.Add(user.CreatedDate.ToString("dd/MM/yyyy"));
                    item.Tag = user;

                    if (!user.IsActive) item.ForeColor = Color.Gray;

                    lvUsers.Items.Add(item);
                }
            }

            lvUsers.EndUpdate();
            lvUsers.Refresh();
            lvUsers.Invalidate();
            UpdateStatistics();
        }

        // ==================== DOUBLE CLICK ====================
        private void LvUsers_DoubleClick(object sender, EventArgs e)
        {
            if (lvUsers.SelectedItems.Count > 0)
            {
                BtnEdit_Click(sender, e);
            }
        }

        private void lvUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
