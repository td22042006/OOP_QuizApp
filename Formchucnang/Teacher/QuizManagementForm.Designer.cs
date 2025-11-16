namespace QuizApp.Teacher
{
    partial class QuizManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ListView lvQuizzes;
        private System.Windows.Forms.ColumnHeader colTitle;
        private System.Windows.Forms.ColumnHeader colDescription;
        private System.Windows.Forms.ColumnHeader colQuestions;
        private System.Windows.Forms.ColumnHeader colPoints;
        private System.Windows.Forms.ColumnHeader colTimeLimit;
        private System.Windows.Forms.Button btnAddQuiz;
        private System.Windows.Forms.Button btnEditQuiz;
        private System.Windows.Forms.Button btnDeleteQuiz;
        private System.Windows.Forms.Button btnViewDetail;
        private System.Windows.Forms.Label lblStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lvQuizzes = new System.Windows.Forms.ListView();
            this.colTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQuestions = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPoints = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTimeLimit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAddQuiz = new System.Windows.Forms.Button();
            this.btnEditQuiz = new System.Windows.Forms.Button();
            this.btnDeleteQuiz = new System.Windows.Forms.Button();
            this.btnViewDetail = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTitle.Location = new System.Drawing.Point(20, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(589, 43);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ ĐỀ THI";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Arial", 10F);
            this.lblSearch.Location = new System.Drawing.Point(16, 74);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(80, 19);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "Tìm kiếm:";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Arial", 10F);
            this.txtSearch.Location = new System.Drawing.Point(133, 70);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(476, 27);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lvQuizzes
            // 
            this.lvQuizzes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTitle,
            this.colDescription,
            this.colQuestions,
            this.colPoints,
            this.colTimeLimit});
            this.lvQuizzes.Font = new System.Drawing.Font("Arial", 9F);
            this.lvQuizzes.FullRowSelect = true;
            this.lvQuizzes.GridLines = true;
            this.lvQuizzes.HideSelection = false;
            this.lvQuizzes.Location = new System.Drawing.Point(16, 117);
            this.lvQuizzes.Name = "lvQuizzes";
            this.lvQuizzes.Size = new System.Drawing.Size(593, 286);
            this.lvQuizzes.TabIndex = 3;
            this.lvQuizzes.UseCompatibleStateImageBehavior = false;
            this.lvQuizzes.View = System.Windows.Forms.View.Details;
            this.lvQuizzes.SelectedIndexChanged += new System.EventHandler(this.lvQuizzes_SelectedIndexChanged);
            // 
            // colTitle
            // 
            this.colTitle.Text = "Tiêu Đề";
            this.colTitle.Width = 150;
            // 
            // colDescription
            // 
            this.colDescription.Text = "Mô Tả";
            this.colDescription.Width = 200;
            // 
            // colQuestions
            // 
            this.colQuestions.Text = "Câu Hỏi";
            this.colQuestions.Width = 70;
            // 
            // colPoints
            // 
            this.colPoints.Text = "Điểm";
            this.colPoints.Width = 70;
            // 
            // colTimeLimit
            // 
            this.colTimeLimit.Text = "Thời Gian";
            this.colTimeLimit.Width = 100;
            // 
            // btnAddQuiz
            // 
            this.btnAddQuiz.BackColor = System.Drawing.Color.Green;
            this.btnAddQuiz.ForeColor = System.Drawing.Color.White;
            this.btnAddQuiz.Location = new System.Drawing.Point(16, 430);
            this.btnAddQuiz.Name = "btnAddQuiz";
            this.btnAddQuiz.Size = new System.Drawing.Size(117, 43);
            this.btnAddQuiz.TabIndex = 4;
            this.btnAddQuiz.Text = "➕ THÊM MỚI";
            this.btnAddQuiz.UseVisualStyleBackColor = false;
            this.btnAddQuiz.Click += new System.EventHandler(this.btnAddQuiz_Click);
            // 
            // btnEditQuiz
            // 
            this.btnEditQuiz.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnEditQuiz.ForeColor = System.Drawing.Color.White;
            this.btnEditQuiz.Location = new System.Drawing.Point(164, 430);
            this.btnEditQuiz.Name = "btnEditQuiz";
            this.btnEditQuiz.Size = new System.Drawing.Size(117, 43);
            this.btnEditQuiz.TabIndex = 5;
            this.btnEditQuiz.Text = "✏️ SỬA";
            this.btnEditQuiz.UseVisualStyleBackColor = false;
            this.btnEditQuiz.Click += new System.EventHandler(this.btnEditQuiz_Click);
            // 
            // btnDeleteQuiz
            // 
            this.btnDeleteQuiz.BackColor = System.Drawing.Color.Crimson;
            this.btnDeleteQuiz.ForeColor = System.Drawing.Color.White;
            this.btnDeleteQuiz.Location = new System.Drawing.Point(328, 430);
            this.btnDeleteQuiz.Name = "btnDeleteQuiz";
            this.btnDeleteQuiz.Size = new System.Drawing.Size(117, 43);
            this.btnDeleteQuiz.TabIndex = 6;
            this.btnDeleteQuiz.Text = "🗑️ XÓA";
            this.btnDeleteQuiz.UseVisualStyleBackColor = false;
            this.btnDeleteQuiz.Click += new System.EventHandler(this.btnDeleteQuiz_Click);
            // 
            // btnViewDetail
            // 
            this.btnViewDetail.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnViewDetail.ForeColor = System.Drawing.Color.White;
            this.btnViewDetail.Location = new System.Drawing.Point(492, 430);
            this.btnViewDetail.Name = "btnViewDetail";
            this.btnViewDetail.Size = new System.Drawing.Size(117, 43);
            this.btnViewDetail.TabIndex = 7;
            this.btnViewDetail.Text = "👁️ XEM CHI TIẾT";
            this.btnViewDetail.UseVisualStyleBackColor = false;
            this.btnViewDetail.Click += new System.EventHandler(this.btnViewDetail_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Arial", 9F);
            this.lblStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblStatus.Location = new System.Drawing.Point(16, 410);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(72, 17);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "Trạng thái";
            // 
            // QuizManagementForm
            // 
            this.ClientSize = new System.Drawing.Size(626, 496);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lvQuizzes);
            this.Controls.Add(this.btnAddQuiz);
            this.Controls.Add(this.btnEditQuiz);
            this.Controls.Add(this.btnDeleteQuiz);
            this.Controls.Add(this.btnViewDetail);
            this.Controls.Add(this.lblStatus);
            this.Name = "QuizManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Đề Thi";
            this.Load += new System.EventHandler(this.QuizManagementForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
