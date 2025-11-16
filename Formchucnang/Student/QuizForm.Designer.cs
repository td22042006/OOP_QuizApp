namespace QuizApp
{
    partial class QuizForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblQuestionNumber;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox grpQuestion;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Panel pnlAnswers;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;

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
            this.lblQuestionNumber = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.grpQuestion = new System.Windows.Forms.GroupBox();
            this.pnlAnswers = new System.Windows.Forms.Panel();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.grpQuestion.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTitle.Location = new System.Drawing.Point(16, 18);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1013, 43);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "BÀI THI TRẮC NGHIỆM";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblQuestionNumber
            // 
            this.lblQuestionNumber.AutoSize = true;
            this.lblQuestionNumber.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lblQuestionNumber.Location = new System.Drawing.Point(27, 74);
            this.lblQuestionNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuestionNumber.Name = "lblQuestionNumber";
            this.lblQuestionNumber.Size = new System.Drawing.Size(90, 22);
            this.lblQuestionNumber.TabIndex = 1;
            this.lblQuestionNumber.Text = "Câu 1/20";
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lblTimer.ForeColor = System.Drawing.Color.Green;
            this.lblTimer.Location = new System.Drawing.Point(827, 74);
            this.lblTimer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(162, 22);
            this.lblTimer.TabIndex = 2;
            this.lblTimer.Text = "Thời gian: 30:00";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Arial", 9F);
            this.lblStatus.Location = new System.Drawing.Point(400, 76);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            this.lblStatus.TabIndex = 3;
            // 
            // grpQuestion
            // 
            this.grpQuestion.Controls.Add(this.pnlAnswers);
            this.grpQuestion.Controls.Add(this.lblQuestion);
            this.grpQuestion.Font = new System.Drawing.Font("Arial", 10F);
            this.grpQuestion.Location = new System.Drawing.Point(27, 111);
            this.grpQuestion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpQuestion.Name = "grpQuestion";
            this.grpQuestion.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpQuestion.Size = new System.Drawing.Size(987, 431);
            this.grpQuestion.TabIndex = 4;
            this.grpQuestion.TabStop = false;
            this.grpQuestion.Text = "Câu hỏi";
            // 
            // pnlAnswers
            // 
            this.pnlAnswers.AutoScroll = true;
            this.pnlAnswers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAnswers.Location = new System.Drawing.Point(20, 123);
            this.pnlAnswers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlAnswers.Name = "pnlAnswers";
            this.pnlAnswers.Size = new System.Drawing.Size(946, 289);
            this.pnlAnswers.TabIndex = 1;
            // 
            // lblQuestion
            // 
            this.lblQuestion.Font = new System.Drawing.Font("Arial", 11F);
            this.lblQuestion.Location = new System.Drawing.Point(20, 37);
            this.lblQuestion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(947, 74);
            this.lblQuestion.TabIndex = 0;
            this.lblQuestion.Text = "Câu hỏi sẽ hiển thị ở đây...";
            this.lblQuestion.Click += new System.EventHandler(this.lblQuestion_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.Color.Gray;
            this.btnPrevious.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnPrevious.ForeColor = System.Drawing.Color.White;
            this.btnPrevious.Location = new System.Drawing.Point(27, 566);
            this.btnPrevious.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(267, 55);
            this.btnPrevious.TabIndex = 5;
            this.btnPrevious.Text = "← Câu trước";
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Green;
            this.btnNext.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(747, 566);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(267, 55);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = "Câu tiếp theo →";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // QuizForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 641);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.grpQuestion);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.lblQuestionNumber);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "QuizForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Làm Bài Thi";
            this.Load += new System.EventHandler(this.QuizForm_Load);
            this.grpQuestion.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}