using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using QuizApp.Models;

namespace QuizApp
{
    public partial class ResultDetailForm : Form
    {
        private QuizResult result;
        private List<Question> questions;
        private List<string> userAnswers;

        public ResultDetailForm(QuizResult res, List<Question> qs, List<string> answers)
        {
            InitializeComponent();
            result = res;
            questions = qs;
            userAnswers = answers;
            DisplayResults();
        }

        private void DisplayResults()
        {
            lblStudentName.Text = "Học sinh: " + result.StudentName;
            lblQuizTitle.Text = "Đề thi: " + result.QuizTitle;
            lblScore.Text = string.Format("Điểm: {0}/{1}",
                result.Score.Value, result.TotalQuestions);
            lblPercentage.Text = "Phần trăm: " + result.GetPercentage().ToString("F1") + "%";
            lblGrade.Text = "Xếp loại: " + result.GetGrade();
            lblTime.Text = "Thời gian: " + result.Duration.ToString(@"mm\:ss");

            DisplayDetailedAnswers();
        }

        private void DisplayDetailedAnswers()
        {
            int yPosition = 10;

            for (int i = 0; i < questions.Count; i++)
            {
                Question q = questions[i];
                string userAnswer = (i < userAnswers.Count) ? userAnswers[i] : "";
                bool isCorrect = q.CheckAnswer(userAnswer);

                Panel pnlQuestion = new Panel();
                pnlQuestion.Location = new Point(10, yPosition);
                pnlQuestion.Size = new Size(pnlDetails.Width - 30, 80);
                pnlQuestion.BorderStyle = BorderStyle.FixedSingle;
                pnlQuestion.BackColor = isCorrect ? Color.LightGreen : Color.LightCoral;

                Label lblQ = new Label();
                lblQ.Text = string.Format("Câu {0}: {1}", i + 1, q.Text);
                lblQ.Location = new Point(10, 10);
                lblQ.Size = new Size(pnlQuestion.Width - 20, 25);
                lblQ.Font = new Font("Arial", 9F, FontStyle.Bold);

                Label lblAnswer = new Label();
                lblAnswer.Text = "Đáp án của bạn: " + (string.IsNullOrEmpty(userAnswer) ? "(Không trả lời)" : userAnswer);
                lblAnswer.Location = new Point(10, 35);
                lblAnswer.Size = new Size(pnlQuestion.Width - 20, 20);

                Label lblCorrect = new Label();
                lblCorrect.Text = "Đáp án đúng: " + q.GetCorrectAnswer();
                lblCorrect.Location = new Point(10, 55);
                lblCorrect.Size = new Size(pnlQuestion.Width - 20, 20);
                lblCorrect.ForeColor = Color.DarkGreen;
                lblCorrect.Font = new Font("Arial", 9F, FontStyle.Bold);

                pnlQuestion.Controls.Add(lblQ);
                pnlQuestion.Controls.Add(lblAnswer);
                pnlQuestion.Controls.Add(lblCorrect);

                pnlDetails.Controls.Add(pnlQuestion);
                yPosition += 85;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnlDetails_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}