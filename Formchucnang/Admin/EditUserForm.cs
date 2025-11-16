using System;
using System.Drawing;
using System.Windows.Forms;
using QuizApp.Managers;
using QuizApp.Models;

namespace QuizApp.Forms.Admin
{
    public partial class EditUserForm : Form
    {
        private User userToEdit;

        public EditUserForm(User user)
        {
            InitializeComponent();
            userToEdit = user;
        }

        private void EditUserForm_Load(object sender, EventArgs e)
        {
            LoadUserData();
        }

        private void LoadUserData()
        {
            txtUsername.Text = userToEdit.Username;
            txtUsername.ReadOnly = true;
            txtFullName.Text = userToEdit.FullName;
            txtEmail.Text = userToEdit.Email;
            txtPhone.Text = userToEdit.Phone;
            txtAddress.Text = userToEdit.Address;

            // Set role
            switch (userToEdit.Role)
            {
                case UserRole.Student:
                    cmbRole.SelectedIndex = 0;
                    break;
                case UserRole.Teacher:
                    cmbRole.SelectedIndex = 1;
                    break;
                case UserRole.Admin:
                    cmbRole.SelectedIndex = 2;
                    break;
            }

            chkIsActive.Checked = userToEdit.IsActive;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Validate fullname
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return;
            }

            // Validate email
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập email!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            // Validate email format
            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Email không hợp lệ!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            // Validate role
            if (cmbRole.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn vai trò!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRole.Focus();
                return;
            }

            // Update user data
            userToEdit.FullName = txtFullName.Text.Trim();
            userToEdit.Email = txtEmail.Text.Trim();
            userToEdit.Phone = txtPhone.Text.Trim();
            userToEdit.Address = txtAddress.Text.Trim();

            switch (cmbRole.SelectedIndex)
            {
                case 0:
                    userToEdit.Role = UserRole.Student;
                    break;
                case 1:
                    userToEdit.Role = UserRole.Teacher;
                    break;
                case 2:
                    userToEdit.Role = UserRole.Admin;
                    break;
            }

            userToEdit.IsActive = chkIsActive.Checked;

            // Save to manager
            bool success = UserManager.Instance.UpdateUser(userToEdit);

            if (success)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePasswordForm changePassForm = new ChangePasswordForm(userToEdit);
            changePassForm.ShowDialog();
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                System.Net.Mail.MailAddress addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}