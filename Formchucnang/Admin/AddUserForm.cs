using System;
using System.Drawing;
using System.Windows.Forms;
using QuizApp.Managers;
using QuizApp.Models;

namespace QuizApp.Forms.Admin
{
    public partial class AddUserForm : Form
    {
        public AddUserForm()
        {
            InitializeComponent();
        }

        private void AddUserForm_Load(object sender, EventArgs e)
        {
            cmbRole.SelectedIndex = 0;
            txtPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Validate username
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            // Validate password
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            // Validate confirm password
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                return;
            }

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

            // Get role from ComboBox
            UserRole role = UserRole.Student;
            switch (cmbRole.SelectedIndex)
            {
                case 0:
                    role = UserRole.Student;
                    break;
                case 1:
                    role = UserRole.Teacher;
                    break;
                case 2:
                    role = UserRole.Admin;
                    break;
            }

            // Add user
            bool success = UserManager.Instance.CreateUserByAdmin(
                txtUsername.Text.Trim(),
                txtPassword.Text,
                txtFullName.Text.Trim(),
                txtEmail.Text.Trim(),
                role
            );

            if (success)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc email đã tồn tại!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
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

        private void ChkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
            txtConfirmPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }
    }
}