using System;
using System.Windows.Forms;
using QuizApp.Managers;

namespace QuizApp
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
            txtFullName.Clear();
            txtEmail.Clear();
            txtUsername.Focus();
        }

        /// <summary>
        /// Kiểm tra định dạng email
        /// </summary>
        private bool IsValidEmail(string email)
        {
            try
            {
                System.Net.Mail.MailAddress addr = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Kiểm tra tính hợp lệ của username
        /// </summary>
        private bool IsValidUsername(string username)
        {
            if (username.Length < 5)
                return false;

            for (int i = 0; i < username.Length; i++)
            {
                char c = username[i];
                if (!char.IsLetterOrDigit(c) && c != '_')
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Kiểm tra tính hợp lệ của mật khẩu
        /// </summary>
        private bool IsValidPassword(string password)
        {
            return password.Length >= 6;
        }

        /// <summary>
        /// Nút đăng ký
        /// </summary>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();

            // Kiểm tra các trường bắt buộc
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (!IsValidUsername(username))
            {
                MessageBox.Show("Tên đăng nhập phải có ít nhất 5 ký tự và chỉ chứa chữ cái, số và dấu gạch dưới!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            if (!IsValidPassword(password))
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            if (!password.Equals(confirmPassword))
            {
                MessageBox.Show("Mật khẩu không trùng khớp!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                return;
            }

            if (string.IsNullOrEmpty(fullName))
            {
                MessageBox.Show("Vui lòng nhập tên đầy đủ!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập email!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Email không hợp lệ!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            // Thực hiện đăng ký
            if (UserManager.Instance.RegisterUser(username, password, fullName, email))
            {
                MessageBox.Show("Đăng ký thành công! Tài khoản của bạn là Học Sinh. Vui lòng đăng nhập.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Đăng ký thất bại! Tên đăng nhập hoặc email đã tồn tại.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Nút hủy
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}