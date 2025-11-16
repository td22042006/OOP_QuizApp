namespace QuizApp
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblNote;

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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblNote = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = false;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTitle.Location = new System.Drawing.Point(30, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(440, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ĐĂNG KÝ TÀI KHOẢN";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblNote
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic);
            this.lblNote.ForeColor = System.Drawing.Color.Gray;
            this.lblNote.Location = new System.Drawing.Point(30, 55);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(250, 16);
            this.lblNote.TabIndex = 1;
            this.lblNote.Text = "(Tài khoản mới sẽ được tạo với role Học Sinh)";

            // lblUsername
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Arial", 10F);
            this.lblUsername.Location = new System.Drawing.Point(30, 80);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(100, 18);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "Tên đăng nhập:";

            // txtUsername
            this.txtUsername.Font = new System.Drawing.Font("Arial", 10F);
            this.txtUsername.Location = new System.Drawing.Point(30, 100);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(440, 26);
            this.txtUsername.TabIndex = 3;

            // lblPassword
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Arial", 10F);
            this.lblPassword.Location = new System.Drawing.Point(30, 135);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(80, 18);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Mật khẩu:";

            // txtPassword
            this.txtPassword.Font = new System.Drawing.Font("Arial", 10F);
            this.txtPassword.Location = new System.Drawing.Point(30, 155);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(440, 26);
            this.txtPassword.TabIndex = 5;

            // lblConfirmPassword
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Font = new System.Drawing.Font("Arial", 10F);
            this.lblConfirmPassword.Location = new System.Drawing.Point(30, 190);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(150, 18);
            this.lblConfirmPassword.TabIndex = 6;
            this.lblConfirmPassword.Text = "Xác nhận mật khẩu:";

            // txtConfirmPassword
            this.txtConfirmPassword.Font = new System.Drawing.Font("Arial", 10F);
            this.txtConfirmPassword.Location = new System.Drawing.Point(30, 210);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(440, 26);
            this.txtConfirmPassword.TabIndex = 7;

            // lblFullName
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Arial", 10F);
            this.lblFullName.Location = new System.Drawing.Point(30, 245);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(100, 18);
            this.lblFullName.TabIndex = 8;
            this.lblFullName.Text = "Tên đầy đủ:";

            // txtFullName
            this.txtFullName.Font = new System.Drawing.Font("Arial", 10F);
            this.txtFullName.Location = new System.Drawing.Point(30, 265);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(440, 26);
            this.txtFullName.TabIndex = 9;

            // lblEmail
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Arial", 10F);
            this.lblEmail.Location = new System.Drawing.Point(30, 300);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(60, 18);
            this.lblEmail.TabIndex = 10;
            this.lblEmail.Text = "Email:";

            // txtEmail
            this.txtEmail.Font = new System.Drawing.Font("Arial", 10F);
            this.txtEmail.Location = new System.Drawing.Point(30, 320);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(440, 26);
            this.txtEmail.TabIndex = 11;

            // btnRegister
            this.btnRegister.BackColor = System.Drawing.Color.Green;
            this.btnRegister.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(150, 370);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(160, 45);
            this.btnRegister.TabIndex = 12;
            this.btnRegister.Text = "ĐĂNG KÝ";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);

            // btnCancel
            this.btnCancel.BackColor = System.Drawing.Color.Crimson;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(320, 370);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(160, 45);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "HỦY";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // RegisterForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(500, 440);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Ký Tài Khoản";
            this.Load += new System.EventHandler(this.RegisterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}