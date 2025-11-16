using QuizApp.Managers;
using QuizApp.Models;
using QuizApp.Teacher;
using System;
using System.Windows.Forms;

namespace QuizApp
{
    public partial class TeacherMainForm : Form
    {
        private XmlDataStore dataStore;

        public TeacherMainForm()
        {
            InitializeComponent();
            dataStore = new XmlDataStore();
        }

        private void TeacherMainForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Chào mừng, " + UserManager.Instance.CurrentUser.FullName + " (Giáo Viên)";
            LoadQuizManagementForm();
        }

        private void btnQuizManagement_Click(object sender, EventArgs e)
        {
            LoadQuizManagementForm();
        }

        private void btnViewHistory_Click(object sender, EventArgs e)
        {
            LoadHistoryViewForm();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn đăng xuất?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                UserManager.Instance.Logout();
                this.Close();
            }
        }

        /// <summary>
        /// Nhúng Form con vào panel và resize full
        /// </summary>
        private void LoadFormInPanel(Form form)
        {
            pnlContent.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(form);
            form.Show();
        }

        private void LoadQuizManagementForm()
        {
            LoadFormInPanel(new QuizManagementForm());
        }

        private void LoadHistoryViewForm()
        {
            LoadFormInPanel(new ResultsForm());
        }

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}