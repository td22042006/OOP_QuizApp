using QuizApp.Forms.Admin;
using QuizApp.Managers;
using QuizApp.Models;
using System;
using System.Windows.Forms;

namespace QuizApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }

        /// <summary>
        /// Nút đăng nhập
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!",
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

            if (UserManager.Instance.Login(username, password))
            {
                MessageBox.Show("Đăng nhập thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Chuyển hướng theo role
                OpenMainFormByRole();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng, hoặc tài khoản đã bị khóa!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtUsername.Focus();
            }
        }

        /// <summary>
        /// Mở form chính theo role của người dùng
        /// </summary>
        private void OpenMainFormByRole()
        {
            Models.User currentUser = UserManager.Instance.CurrentUser;

            if (currentUser == null)
                return;

            switch (currentUser.Role)
            {
                case Models.UserRole.Admin:
                    // Mở Admin Form
                    AdminMainForm adminForm = new AdminMainForm();
                    adminForm.Show();
                    break;

                case Models.UserRole.Teacher:
                    // Mở Teacher Form
                    TeacherMainForm teacherForm = new TeacherMainForm();
                    teacherForm.Show();
                    break;

                case Models.UserRole.Student:
                    // Mở Student Form
                    MainForm studentForm = new MainForm();
                    studentForm.Show();
                    break;

                default:
                    MessageBox.Show("Role không xác định!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        /// <summary>
        /// Nút đăng ký
        /// </summary>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }

        /// <summary>
        /// Nút thoát
        /// </summary>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Cho phép nhấn Enter để đăng nhập
        /// </summary>
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                btnLogin_Click(null, null);
                e.SuppressKeyPress = true; // <-- sửa từ SuppressKeyDown
            }
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}