using System;
using System.Drawing;
using System.Windows.Forms;
using QuizApp.Managers;
using QuizApp.Models;

namespace QuizApp.Forms.Admin
{
    public partial class AdminMainForm : Form
    {
        private UserManagementForm userManagementControl;

        public AdminMainForm()
        {
            InitializeComponent();
        }

        private void AdminMainForm_Load(object sender, EventArgs e)
        {
            LoadUserInfo();
            SetActiveButton(btnUserManagement);
            LoadUserManagement();
        }

        private void LoadUserInfo()
        {
            User currentUser = UserManager.Instance.CurrentUser;
            if (currentUser != null)
            {
                lblUserInfo.Text = currentUser.FullName;
            }
            else
            {
                lblUserInfo.Text = "Admin";
            }
        }

        private void SetActiveButton(Button activeButton)
        {
            // Reset tất cả button về màu mặc định
            btnUserManagement.BackColor = Color.FromArgb(44, 62, 80);
            btnSystemSettings.BackColor = Color.FromArgb(44, 62, 80);

            // Set button active
            activeButton.BackColor = Color.FromArgb(41, 128, 185);
        }

        private void BtnUserManagement_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnUserManagement);
            LoadUserManagement();
        }

        private void BtnSystemSettings_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnSystemSettings);
            LoadSystemSettings();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn đăng xuất?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void LoadUserManagement()
        {
            pnlContent.Controls.Clear();
            userManagementControl = new UserManagementForm();
            userManagementControl.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(userManagementControl);
        }

        private void LoadStatistics()
        {
            pnlContent.Controls.Clear();

            Panel statsPanel = new Panel();
            statsPanel.Dock = DockStyle.Fill;
            statsPanel.Padding = new Padding(20);
            statsPanel.AutoScroll = true;
            statsPanel.BackColor = Color.White;

            Label lblTitle = new Label();
            lblTitle.Text = "THỐNG KÊ HỆ THỐNG";
            lblTitle.Font = new Font("Arial", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(52, 73, 94);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Size = new Size(400, 35);
            statsPanel.Controls.Add(lblTitle);

            // Lấy thống kê
            int students = UserManager.Instance.GetUserCountByRole(UserRole.Student);
            int teachers = UserManager.Instance.GetUserCountByRole(UserRole.Teacher);
            int admins = UserManager.Instance.GetUserCountByRole(UserRole.Admin);
            int totalUsers = UserManager.Instance.Users.Count;
            int totalQuizzes = QuizManager.Instance.GetQuizCount();

            // Tạo các card thống kê
            CreateStatCard(statsPanel, "Tổng người dùng", totalUsers.ToString(), 20, 80, Color.FromArgb(52, 152, 219));
            CreateStatCard(statsPanel, "Học sinh", students.ToString(), 270, 80, Color.FromArgb(46, 204, 113));
            CreateStatCard(statsPanel, "Giáo viên", teachers.ToString(), 520, 80, Color.FromArgb(155, 89, 182));
            CreateStatCard(statsPanel, "Quản trị viên", admins.ToString(), 770, 80, Color.FromArgb(231, 76, 60));
            CreateStatCard(statsPanel, "Tổng đề thi", totalQuizzes.ToString(), 20, 220, Color.FromArgb(241, 196, 15));

            pnlContent.Controls.Add(statsPanel);
        }

        private void CreateStatCard(Panel parent, string label, string value, int x, int y, Color color)
        {
            Panel card = new Panel();
            card.Location = new Point(x, y);
            card.Size = new Size(230, 120);
            card.BackColor = color;
            card.BorderStyle = BorderStyle.None;

            Label lblValue = new Label();
            lblValue.Text = value;
            lblValue.Font = new Font("Arial", 32F, FontStyle.Bold);
            lblValue.ForeColor = Color.White;
            lblValue.Location = new Point(10, 20);
            lblValue.Size = new Size(210, 50);
            lblValue.TextAlign = ContentAlignment.MiddleCenter;

            Label lblLabel = new Label();
            lblLabel.Text = label;
            lblLabel.Font = new Font("Arial", 11F, FontStyle.Bold);
            lblLabel.ForeColor = Color.White;
            lblLabel.Location = new Point(10, 75);
            lblLabel.Size = new Size(210, 30);
            lblLabel.TextAlign = ContentAlignment.MiddleCenter;

            card.Controls.Add(lblValue);
            card.Controls.Add(lblLabel);
            parent.Controls.Add(card);
        }

        private void LoadSystemSettings()
        {
            pnlContent.Controls.Clear();

            Panel settingsPanel = new Panel();
            settingsPanel.Dock = DockStyle.Fill;
            settingsPanel.Padding = new Padding(20);
            settingsPanel.AutoScroll = true;
            settingsPanel.BackColor = Color.White;

            Label lblTitle = new Label();
            lblTitle.Text = "CÀI ĐẶT HỆ THỐNG";
            lblTitle.Font = new Font("Arial", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(52, 73, 94);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Size = new Size(400, 35);
            settingsPanel.Controls.Add(lblTitle);

            // Group Box: Quản lý dữ liệu
            GroupBox gbData = new GroupBox();
            gbData.Text = "Quản lý dữ liệu";
            gbData.Font = new Font("Arial", 11F, FontStyle.Bold);
            gbData.Location = new Point(20, 80);
            gbData.Size = new Size(850, 150);

            Button btnResetUsers = new Button();
            btnResetUsers.Text = "Reset tất cả người dùng";
            btnResetUsers.Location = new Point(20, 40);
            btnResetUsers.Size = new Size(200, 40);
            btnResetUsers.BackColor = Color.FromArgb(231, 76, 60);
            btnResetUsers.ForeColor = Color.White;
            btnResetUsers.FlatStyle = FlatStyle.Flat;
            btnResetUsers.Font = new Font("Arial", 10F, FontStyle.Bold);
            btnResetUsers.Cursor = Cursors.Hand;
            btnResetUsers.Click += new EventHandler(BtnResetUsers_Click);

            Button btnResetQuizzes = new Button();
            btnResetQuizzes.Text = "Reset tất cả đề thi";
            btnResetQuizzes.Location = new Point(240, 40);
            btnResetQuizzes.Size = new Size(200, 40);
            btnResetQuizzes.BackColor = Color.FromArgb(230, 126, 34);
            btnResetQuizzes.ForeColor = Color.White;
            btnResetQuizzes.FlatStyle = FlatStyle.Flat;
            btnResetQuizzes.Font = new Font("Arial", 10F, FontStyle.Bold);
            btnResetQuizzes.Cursor = Cursors.Hand;
            btnResetQuizzes.Click += new EventHandler(BtnResetQuizzes_Click);


            Button btnGenerateSampleData = new Button();
            btnGenerateSampleData.Text = "Tạo dữ liệu mẫu (Quiz)";
            btnGenerateSampleData.Location = new Point(20, 90);
            btnGenerateSampleData.Size = new Size(200, 40);
            btnGenerateSampleData.BackColor = Color.FromArgb(46, 204, 113);
            btnGenerateSampleData.ForeColor = Color.White;
            btnGenerateSampleData.FlatStyle = FlatStyle.Flat;
            btnGenerateSampleData.Font = new Font("Arial", 10F, FontStyle.Bold);
            btnGenerateSampleData.Cursor = Cursors.Hand;
            btnGenerateSampleData.Click += new EventHandler(BtnGenerateSampleData_Click);

            gbData.Controls.Add(btnResetUsers);
            gbData.Controls.Add(btnResetQuizzes);
            gbData.Controls.Add(btnGenerateSampleData);
            settingsPanel.Controls.Add(gbData);

            pnlContent.Controls.Add(settingsPanel);
        }

        private void BtnResetUsers_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "CẢNH BÁO: Thao tác này sẽ xóa TẤT CẢ người dùng (trừ admin)!\nBạn có chắc chắn?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                UserManager.Instance.ClearAllUsers();
                MessageBox.Show("Đã reset tất cả người dùng!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadStatistics();
            }
        }

        private void BtnResetQuizzes_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Thao tác này sẽ xóa TẤT CẢ đề thi!\nBạn có chắc chắn?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                QuizManager.Instance.ClearAllQuizzes();
                MessageBox.Show("Đã reset tất cả đề thi!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadStatistics();
            }
        }


        private void BtnGenerateSampleData_Click(object sender, EventArgs e)
        {
            SampleDataGenerator.GenerateAllSampleData();
            MessageBox.Show("Đã tạo dữ liệu mẫu!", "Thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadStatistics();
        }

        private void MenuButton_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.BackColor != Color.FromArgb(41, 128, 185) && btn != btnLogout)
            {
                btn.BackColor = Color.FromArgb(52, 73, 94);
            }
        }

        private void MenuButton_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.BackColor != Color.FromArgb(41, 128, 185) && btn != btnLogout)
            {
                btn.BackColor = Color.FromArgb(44, 62, 80);
            }
        }

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}