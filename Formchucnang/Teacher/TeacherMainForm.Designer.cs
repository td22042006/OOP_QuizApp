namespace QuizApp
{
    partial class TeacherMainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnQuizManagement;
        private System.Windows.Forms.Button btnViewHistory;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlMenu;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnQuizManagement = new System.Windows.Forms.Button();
            this.btnViewHistory = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(20, 20);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(600, 30);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Chào mừng, [Teacher Name]";
            // 
            // btnQuizManagement
            // 
            this.btnQuizManagement.BackColor = System.Drawing.Color.SeaGreen;
            this.btnQuizManagement.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnQuizManagement.ForeColor = System.Drawing.Color.White;
            this.btnQuizManagement.Location = new System.Drawing.Point(20, 90);
            this.btnQuizManagement.Name = "btnQuizManagement";
            this.btnQuizManagement.Size = new System.Drawing.Size(233, 50);
            this.btnQuizManagement.TabIndex = 4;
            this.btnQuizManagement.Text = "📚 QUẢN LÝ ĐỀ THI";
            this.btnQuizManagement.UseVisualStyleBackColor = false;
            this.btnQuizManagement.Click += new System.EventHandler(this.btnQuizManagement_Click);
            // 
            // btnViewHistory
            // 
            this.btnViewHistory.BackColor = System.Drawing.Color.CadetBlue;
            this.btnViewHistory.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnViewHistory.ForeColor = System.Drawing.Color.White;
            this.btnViewHistory.Location = new System.Drawing.Point(20, 146);
            this.btnViewHistory.Name = "btnViewHistory";
            this.btnViewHistory.Size = new System.Drawing.Size(233, 50);
            this.btnViewHistory.TabIndex = 2;
            this.btnViewHistory.Text = "📋 LỊCH SỬ LÀM BÀI";
            this.btnViewHistory.UseVisualStyleBackColor = false;
            this.btnViewHistory.Click += new System.EventHandler(this.btnViewHistory_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Orange;
            this.btnLogout.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(822, 19);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(120, 35);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "ĐĂNG XUẤT";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(455, 19);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 2;
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.Location = new System.Drawing.Point(259, 90);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(731, 540);
            this.pnlContent.TabIndex = 0;
            this.pnlContent.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlContent_Paint);
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.DarkGreen;
            this.pnlMenu.Controls.Add(this.lblWelcome);
            this.pnlMenu.Controls.Add(this.btnLogout);
            this.pnlMenu.Controls.Add(this.btnExit);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(1000, 70);
            this.pnlMenu.TabIndex = 5;
            // 
            // TeacherMainForm
            // 
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.btnViewHistory);
            this.Controls.Add(this.btnQuizManagement);
            this.Controls.Add(this.pnlMenu);
            this.Name = "TeacherMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giáo Viên - Hệ Thống Quản Lý Thi Trắc Nghiệm";
            this.Load += new System.EventHandler(this.TeacherMainForm_Load);
            this.pnlMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}