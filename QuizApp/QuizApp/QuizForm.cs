using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using QuizApp.Models;
using QuizApp.Managers;

namespace QuizApp
{
    public partial class QuizForm : Form
    {
        private Quiz currentQuiz;
        private string studentName;
        private int currentIndex;
        private Score userScore;
        private List<string> userAnswers;
        private DateTime startTime;
        private Timer quizTimer;
        private int remainingSeconds;

        public QuizForm(Quiz quiz, string name)
        {
            InitializeComponent();
            currentQuiz = quiz;
            studentName = name;
            currentIndex = 0;
            userScore = new Score(0);
            userAnswers = new List<string>();
            startTime = DateTime.Now;

            // Khởi tạo timer
            remainingSeconds = quiz.TimeLimit * 60;
            quizTimer = new Timer();
            quizTimer.Interval = 1000; // 1 giây
            quizTimer.Tick += QuizTimer_Tick;

            // Đăng ký event
            currentQuiz.QuizStarted += Quiz_Started;
            currentQuiz.QuizCompleted += Quiz_Completed;

            // Bắt đầu quiz
            currentQuiz.Start();
            ShowQuestion(currentIndex);
            quizTimer.Start();
        }

        /// <summary>
        /// Xử lý sự kiện quiz bắt đầu
        /// </summary>
        private void Quiz_Started(object sender, EventArgs e)
        {
            lblStatus.Text = "Bài thi đã bắt đầu!";
            lblStatus.ForeColor = Color.Green;
        }

        /// <summary>
        /// Xử lý sự kiện quiz hoàn thành
        /// </summary>
        private void Quiz_Completed(object sender, EventArgs e)
        {
            quizTimer.Stop();
            ShowResults();
        }

        /// <summary>
        /// Xử lý timer
        /// </summary>
        private void QuizTimer_Tick(object sender, EventArgs e)
        {
            remainingSeconds--;

            int minutes = remainingSeconds / 60;
            int seconds = remainingSeconds % 60;
            lblTimer.Text = string.Format("Thời gian: {0:00}:{1:00}", minutes, seconds);

            if (remainingSeconds <= 60)
            {
                lblTimer.ForeColor = Color.Red;
            }

            if (remainingSeconds <= 0)
            {
                quizTimer.Stop();
                MessageBox.Show("Hết thời gian!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                FinishQuiz();
            }
        }

        /// <summary>
        /// Hiển thị câu hỏi
        /// </summary>
        private void ShowQuestion(int index)
        {
            if (index < 0 || index >= currentQuiz.Questions.Count)
                return;

            Question q = currentQuiz.Questions[index];

            lblQuestionNumber.Text = string.Format("Câu {0}/{1}",
                index + 1, currentQuiz.Questions.Count);
            lblQuestion.Text = q.Text;

            // Xóa các radio button cũ
            pnlAnswers.Controls.Clear();

            if (q is MultipleChoiceQuestion mcq)
            {
                ShowMultipleChoiceAnswers(mcq);
            }
            else if (q is TrueFalseQuestion tfq)
            {
                ShowTrueFalseAnswers();
            }

            // Cập nhật trạng thái nút
            btnPrevious.Enabled = (index > 0);
            btnNext.Text = (index < currentQuiz.Questions.Count - 1) ? "Câu tiếp theo" : "Hoàn thành";

            // Nếu đã trả lời câu này trước đó, chọn lại
            if (index < userAnswers.Count && !string.IsNullOrEmpty(userAnswers[index]))
            {
                SelectPreviousAnswer(userAnswers[index]);
            }
        }

        /// <summary>
        /// Hiển thị câu hỏi trắc nghiệm
        /// </summary>
        private void ShowMultipleChoiceAnswers(MultipleChoiceQuestion mcq)
        {
            int yPosition = 10;

            for (int i = 0; i < mcq.Choices.Count; i++)
            {
                RadioButton rb = new RadioButton();
                rb.Text = mcq.Choices[i];
                rb.Location = new Point(10, yPosition);
                rb.Size = new Size(pnlAnswers.Width - 30, 30);
                rb.Font = new Font("Arial", 10F);
                rb.Tag = mcq.Choices[i];

                pnlAnswers.Controls.Add(rb);
                yPosition += 35;
            }
        }

        /// <summary>
        /// Hiển thị câu hỏi đúng/sai
        /// </summary>
        private void ShowTrueFalseAnswers()
        {
            RadioButton rbTrue = new RadioButton();
            rbTrue.Text = "Đúng";
            rbTrue.Location = new Point(10, 10);
            rbTrue.Size = new Size(200, 30);
            rbTrue.Font = new Font("Arial", 10F);
            rbTrue.Tag = "Đúng";

            RadioButton rbFalse = new RadioButton();
            rbFalse.Text = "Sai";
            rbFalse.Location = new Point(10, 45);
            rbFalse.Size = new Size(200, 30);
            rbFalse.Font = new Font("Arial", 10F);
            rbFalse.Tag = "Sai";

            pnlAnswers.Controls.Add(rbTrue);
            pnlAnswers.Controls.Add(rbFalse);
        }

        /// <summary>
        /// Chọn lại câu trả lời đã chọn
        /// </summary>
        private void SelectPreviousAnswer(string answer)
        {
            foreach (Control ctrl in pnlAnswers.Controls)
            {
                if (ctrl is RadioButton rb)
                {
                    if (rb.Tag.ToString() == answer)
                    {
                        rb.Checked = true;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Lấy câu trả lời người dùng chọn
        /// </summary>
        private string GetUserAnswer()
        {
            foreach (Control ctrl in pnlAnswers.Controls)
            {
                if (ctrl is RadioButton rb && rb.Checked)
                {
                    return rb.Tag.ToString();
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// Lưu câu trả lời
        /// </summary>
        private void SaveAnswer()
        {
            string answer = GetUserAnswer();

            if (currentIndex < userAnswers.Count)
            {
                userAnswers[currentIndex] = answer;
            }
            else
            {
                userAnswers.Add(answer);
            }
        }

        /// <summary>
        /// Nút câu trước
        /// </summary>
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            SaveAnswer();
            currentIndex--;
            ShowQuestion(currentIndex);
        }

        /// <summary>
        /// Nút câu tiếp / hoàn thành
        /// </summary>
        private void btnNext_Click(object sender, EventArgs e)
        {
            string answer = GetUserAnswer();

            if (string.IsNullOrEmpty(answer))
            {
                DialogResult result = MessageBox.Show(
                    "Bạn chưa chọn đáp án. Bạn có muốn tiếp tục?",
                    "Thông báo",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                    return;
            }

            SaveAnswer();

            if (currentIndex < currentQuiz.Questions.Count - 1)
            {
                currentIndex++;
                ShowQuestion(currentIndex);
            }
            else
            {
                FinishQuiz();
            }
        }

        /// <summary>
        /// Hoàn thành bài thi
        /// </summary>
        private void FinishQuiz()
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn nộp bài?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                CalculateScore();
                currentQuiz.Complete();
            }
        }

        /// <summary>
        /// Tính điểm
        /// </summary>
        private void CalculateScore()
        {
            userScore = new Score(0);

            for (int i = 0; i < currentQuiz.Questions.Count; i++)
            {
                Question q = currentQuiz.Questions[i];
                string answer = (i < userAnswers.Count) ? userAnswers[i] : string.Empty;

                if (q.CheckAnswer(answer))
                {
                    userScore = userScore + new Score(q.Points);
                }
            }
        }

        /// <summary>
        /// Hiển thị kết quả
        /// </summary>
        private void ShowResults()
        {
            TimeSpan duration = DateTime.Now - startTime;

            QuizResult result = new QuizResult(
                studentName,
                currentQuiz.Title,
                userScore,
                currentQuiz.GetQuestionCount(),
                duration);

            // Lưu kết quả
            SaveResult(result);

            // Hiển thị form kết quả
            ResultDetailForm detailForm = new ResultDetailForm(
                result, currentQuiz.Questions, userAnswers);
            detailForm.ShowDialog();

            this.Close();
        }

        /// <summary>
        /// Lưu kết quả vào file
        /// </summary>
        private void SaveResult(QuizResult result)
        {
            try
            {
                XmlDataStore dataStore = new XmlDataStore();
                List<QuizResult> results = dataStore.LoadResults("results.xml");
                results.Add(result);
                dataStore.SaveResults("results.xml", results);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu kết quả: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý khi đóng form
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (quizTimer.Enabled)
            {
                DialogResult result = MessageBox.Show(
                    "Bài thi chưa hoàn thành. Bạn có chắc muốn thoát?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }

                quizTimer.Stop();
            }

            base.OnFormClosing(e);
        }

        private void pnlAnswers_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}