namespace QuizApp.Forms.Admin
{
    partial class AdminMainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.Button btnUserManagement;
        private System.Windows.Forms.Button btnSystemSettings;
        private System.Windows.Forms.Button btnLogout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.btnUserManagement = new System.Windows.Forms.Button();
            this.btnSystemSettings = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlSidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.pnlSidebar.Controls.Add(this.lblWelcome);
            this.pnlSidebar.Controls.Add(this.lblUserInfo);
            this.pnlSidebar.Controls.Add(this.btnUserManagement);
            this.pnlSidebar.Controls.Add(this.btnSystemSettings);
            this.pnlSidebar.Controls.Add(this.btnLogout);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Margin = new System.Windows.Forms.Padding(4);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(333, 862);
            this.pnlSidebar.TabIndex = 0;
            // 
            // lblWelcome
            // 
            this.lblWelcome.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(27, 25);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(280, 37);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "QUẢN TRỊ VIÊN";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(195)))), ((int)(((byte)(199)))));
            this.lblUserInfo.Location = new System.Drawing.Point(27, 68);
            this.lblUserInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(280, 25);
            this.lblUserInfo.TabIndex = 1;
            this.lblUserInfo.Text = "Administrator";
            this.lblUserInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnUserManagement
            // 
            this.btnUserManagement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnUserManagement.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUserManagement.FlatAppearance.BorderSize = 0;
            this.btnUserManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserManagement.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserManagement.ForeColor = System.Drawing.Color.White;
            this.btnUserManagement.Location = new System.Drawing.Point(20, 123);
            this.btnUserManagement.Margin = new System.Windows.Forms.Padding(4);
            this.btnUserManagement.Name = "btnUserManagement";
            this.btnUserManagement.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnUserManagement.Size = new System.Drawing.Size(293, 49);
            this.btnUserManagement.TabIndex = 2;
            this.btnUserManagement.Text = "Quản lý người dùng";
            this.btnUserManagement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserManagement.UseVisualStyleBackColor = false;
            this.btnUserManagement.Click += new System.EventHandler(this.BtnUserManagement_Click);
            this.btnUserManagement.MouseEnter += new System.EventHandler(this.MenuButton_MouseEnter);
            this.btnUserManagement.MouseLeave += new System.EventHandler(this.MenuButton_MouseLeave);
            // 
            // btnSystemSettings
            // 
            this.btnSystemSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnSystemSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSystemSettings.FlatAppearance.BorderSize = 0;
            this.btnSystemSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSystemSettings.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSystemSettings.ForeColor = System.Drawing.Color.White;
            this.btnSystemSettings.Location = new System.Drawing.Point(20, 180);
            this.btnSystemSettings.Margin = new System.Windows.Forms.Padding(4);
            this.btnSystemSettings.Name = "btnSystemSettings";
            this.btnSystemSettings.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnSystemSettings.Size = new System.Drawing.Size(293, 49);
            this.btnSystemSettings.TabIndex = 4;
            this.btnSystemSettings.Text = "Cài đặt hệ thống";
            this.btnSystemSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSystemSettings.UseVisualStyleBackColor = false;
            this.btnSystemSettings.Click += new System.EventHandler(this.BtnSystemSettings_Click);
            this.btnSystemSettings.MouseEnter += new System.EventHandler(this.MenuButton_MouseEnter);
            this.btnSystemSettings.MouseLeave += new System.EventHandler(this.MenuButton_MouseLeave);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(20, 763);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(293, 49);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(333, 0);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(4);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1267, 862);
            this.pnlContent.TabIndex = 1;
            this.pnlContent.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlContent_Paint);
            // 
            // AdminMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1600, 862);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSidebar);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AdminMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Trị Hệ Thống - Admin Panel";
            this.Load += new System.EventHandler(this.AdminMainForm_Load);
            this.pnlSidebar.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}