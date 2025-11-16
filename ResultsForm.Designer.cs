namespace QuizApp
{
    partial class ResultsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ListView lvResults;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colQuiz;
        private System.Windows.Forms.ColumnHeader colScore;
        private System.Windows.Forms.ColumnHeader colTotal;
        private System.Windows.Forms.ColumnHeader colPercent;
        private System.Windows.Forms.ColumnHeader colGrade;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClear;

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
            this.lvResults = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQuiz = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colScore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPercent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGrade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTitle.Location = new System.Drawing.Point(16, 18);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1147, 43);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "LỊCH SỬ KẾT QUẢ THI";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lvResults
            // 
            this.lvResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colQuiz,
            this.colScore,
            this.colTotal,
            this.colPercent,
            this.colGrade,
            this.colDate});
            this.lvResults.Font = new System.Drawing.Font("Arial", 9F);
            this.lvResults.FullRowSelect = true;
            this.lvResults.GridLines = true;
            this.lvResults.HideSelection = false;
            this.lvResults.Location = new System.Drawing.Point(27, 80);
            this.lvResults.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lvResults.Name = "lvResults";
            this.lvResults.Size = new System.Drawing.Size(1119, 467);
            this.lvResults.TabIndex = 1;
            this.lvResults.UseCompatibleStateImageBehavior = false;
            this.lvResults.View = System.Windows.Forms.View.Details;
            this.lvResults.SelectedIndexChanged += new System.EventHandler(this.lvResults_SelectedIndexChanged);
            // 
            // colName
            // 
            this.colName.Text = "Tên học sinh";
            this.colName.Width = 150;
            // 
            // colQuiz
            // 
            this.colQuiz.Text = "Đề thi";
            this.colQuiz.Width = 200;
            // 
            // colScore
            // 
            this.colScore.Text = "Điểm";
            // 
            // colTotal
            // 
            this.colTotal.Text = "Tổng";
            // 
            // colPercent
            // 
            this.colPercent.Text = "Phần trăm";
            this.colPercent.Width = 80;
            // 
            // colGrade
            // 
            this.colGrade.Text = "Xếp loại";
            this.colGrade.Width = 100;
            // 
            // colDate
            // 
            this.colDate.Text = "Ngày thi";
            this.colDate.Width = 150;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Crimson;
            this.btnClose.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(880, 572);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(267, 55);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "ĐÓNG";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Orange;
            this.btnClear.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(27, 572);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(267, 55);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "XÓA TẤT CẢ";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // ResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 654);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lvResults);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "ResultsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kết Quả Thi";
            this.ResumeLayout(false);

        }
    }
}