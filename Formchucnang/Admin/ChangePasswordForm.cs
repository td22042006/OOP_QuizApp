using System;
using System.Drawing;
using System.Windows.Forms;
using QuizApp.Managers;
using QuizApp.Models;
using System.Security.Cryptography;
using System.Text;

namespace QuizApp.Forms.Admin
{
    public partial class ChangePasswordForm : Form
    {
        private User userToChange;

        public ChangePasswordForm(User user)
        {
            InitializeComponent();
            userToChange = user;
        }

        private void ChangePasswordForm_Load(object sender, EventArgs e)
        {
            lblUserInfo.Text = string.Format("Đổi mật khẩu cho: {0}", userToChange.Username);
            txtNewPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return;
            }

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                return;
            }

            // Update password hash
            userToChange.PasswordHash = HashPassword(txtNewPassword.Text);
            bool success = UserManager.Instance.UpdateUser(userToChange);

            if (success)
            {
                MessageBox.Show("Đổi mật khẩu thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Đổi mật khẩu thất bại!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ChkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtNewPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
            txtConfirmPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }
}