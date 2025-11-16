using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using QuizApp.Managers;
using QuizApp.Models;

namespace QuizApp.Teacher
{
    public partial class QuizManagementForm : Form
    {
        private XmlDataStore dataStore;

        public QuizManagementForm()
        {
            InitializeComponent();
            dataStore = new XmlDataStore();
        }

        private void QuizManagementForm_Load(object sender, EventArgs e)
        {
            LoadQuizzes();
        }

        private void LoadQuizzes()
        {
            lvQuizzes.Items.Clear();

            List<Quiz> allQuizzes = QuizManager.Instance.Quizzes;

            for (int i = 0; i < allQuizzes.Count; i++)
            {
                Quiz quiz = allQuizzes[i];
                ListViewItem item = new ListViewItem(quiz.Title);
                item.SubItems.Add(quiz.Description);
                item.SubItems.Add(quiz.GetQuestionCount().ToString());
                item.SubItems.Add(quiz.GetTotalPoints().ToString());
                item.SubItems.Add(quiz.TimeLimit + " phút");
                item.Tag = quiz;
                lvQuizzes.Items.Add(item);
            }

            if (lvQuizzes.Items.Count == 0)
            {
                lblStatus.Text = "Chưa có đề thi nào. Vui lòng tạo mới.";
            }
            else
            {
                lblStatus.Text = "Tổng cộng: " + lvQuizzes.Items.Count + " đề thi";
            }
        }

        private void btnAddQuiz_Click(object sender, EventArgs e)
        {
            // Chọn file txt làm đề
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files|*.txt";
            ofd.Title = "Chọn file đề thi";
            if (ofd.ShowDialog() != DialogResult.OK) return;

            string title = Path.GetFileNameWithoutExtension(ofd.FileName);

            if (QuizManager.Instance.FindQuizByTitle(title) != null)
            {
                MessageBox.Show("Tên đề thi đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string description = PromptForString("Nhập mô tả đề thi:", "Mô tả");
            string timeLimitStr = PromptForString("Nhập thời gian (phút):", "Thời gian", "30");

            int timeLimit = 30;
            if (!int.TryParse(timeLimitStr, out timeLimit) || timeLimit <= 0)
            {
                MessageBox.Show("Thời gian phải là số dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tạo quiz mới và nạp câu hỏi từ file
            Quiz newQuiz = new Quiz(title, description);
            newQuiz.TimeLimit = timeLimit;
            newQuiz.FilePath = ofd.FileName;
            newQuiz.Questions = LoadQuestionsFromFile(ofd.FileName); // <-- thêm dòng này

            QuizManager.Instance.AddQuiz(newQuiz);

            dataStore.Save("quizzes.xml");
            LoadQuizzes();
            MessageBox.Show("Đã thêm đề thi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private List<Question> LoadQuestionsFromFile(string filePath)
        {
            List<Question> questions = new List<Question>();

            if (!System.IO.File.Exists(filePath))
                return questions;

            string[] lines = System.IO.File.ReadAllLines(filePath);
            Question currentQuestion = null;

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].Trim();

                if (line.StartsWith("Q:")) // câu hỏi
                {
                    string text = line.Substring(2).Trim();

                    if (text.StartsWith("[TrueFalse]"))
                    {
                        string questionText = text.Substring(11).Trim();
                        TrueFalseQuestion tfq = new TrueFalseQuestion(); // dùng constructor mặc định
                        tfq.Text = questionText;
                        currentQuestion = tfq;
                    }
                    else
                    {
                        MultipleChoiceQuestion mcq = new MultipleChoiceQuestion(); // dùng constructor mặc định
                        mcq.Text = text;
                        currentQuestion = mcq;
                    }

                    questions.Add(currentQuestion);
                }
                else if (line.StartsWith("A:") && currentQuestion != null)
                {
                    if (currentQuestion is MultipleChoiceQuestion mcq)
                    {
                        mcq.Choices.Add(line.Substring(2).Trim());
                    }
                }
                else if (line.StartsWith("ANS:") && currentQuestion != null)
                {
                    string ans = line.Substring(4).Trim();

                    if (currentQuestion is MultipleChoiceQuestion mcq)
                    {
                        int correctIdx = -1;
                        for (int j = 0; j < mcq.Choices.Count; j++)
                        {
                            if (mcq.Choices[j].Trim().Equals(ans, StringComparison.OrdinalIgnoreCase))
                            {
                                correctIdx = j;
                                break;
                            }
                        }
                        mcq.CorrectIndex = correctIdx;
                    }
                    else if (currentQuestion is TrueFalseQuestion tfq)
                    {
                        if (ans.ToLower() == "true" || ans.ToLower() == "đúng")
                        {
                            tfq.CorrectAnswer = true;
                        }
                        else if (ans.ToLower() == "false" || ans.ToLower() == "sai")
                        {
                            tfq.CorrectAnswer = false;
                        }
                    }
                }
            }

            return questions;
        }



        private void btnEditQuiz_Click(object sender, EventArgs e)
        {
            if (lvQuizzes.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn đề thi để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Quiz selectedQuiz = (Quiz)lvQuizzes.SelectedItems[0].Tag;

            // Có thể chọn file txt mới
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files|*.txt";
            ofd.Title = "Chọn file đề thi (nếu muốn đổi)";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                selectedQuiz.FilePath = ofd.FileName;
                selectedQuiz.Title = Path.GetFileNameWithoutExtension(ofd.FileName);
                selectedQuiz.Questions = LoadQuestionsFromFile(ofd.FileName); // <--- nạp lại câu hỏi
            }

            string description = PromptForString("Nhập mô tả mới:", "Mô tả", selectedQuiz.Description);
            string timeLimitStr = PromptForString("Nhập thời gian (phút):", "Thời gian", selectedQuiz.TimeLimit.ToString());

            int timeLimit = 30;
            if (!int.TryParse(timeLimitStr, out timeLimit) || timeLimit <= 0)
            {
                MessageBox.Show("Thời gian phải là số dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            selectedQuiz.Description = description;
            selectedQuiz.TimeLimit = timeLimit;

            dataStore.Save("quizzes.xml");
            LoadQuizzes();
            MessageBox.Show("Đã cập nhật đề thi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDeleteQuiz_Click(object sender, EventArgs e)
        {
            if (lvQuizzes.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn đề thi để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Quiz selectedQuiz = (Quiz)lvQuizzes.SelectedItems[0].Tag;

            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa đề thi này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            QuizManager.Instance.RemoveQuiz(selectedQuiz);
            dataStore.Save("quizzes.xml");
            LoadQuizzes();
            MessageBox.Show("Đã xóa đề thi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            if (lvQuizzes.SelectedItems.Count == 0) return;

            Quiz selectedQuiz = (Quiz)lvQuizzes.SelectedItems[0].Tag;

            string content = "";
            if (!string.IsNullOrEmpty(selectedQuiz.FilePath) && File.Exists(selectedQuiz.FilePath))
            {
                content = File.ReadAllText(selectedQuiz.FilePath);
            }
            else
            {
                content = "Không có nội dung đề thi!";
            }

            string detail = "Tiêu đề: " + selectedQuiz.Title + "\n" +
                            "Mô tả: " + selectedQuiz.Description + "\n" +
                            "Số câu hỏi: " + selectedQuiz.GetQuestionCount() + "\n" +
                            "Tổng điểm: " + selectedQuiz.GetTotalPoints() + "\n" +
                            "Thời gian: " + selectedQuiz.TimeLimit + " phút\n\n" +
                            "Nội dung đề:\n" + content;

            MessageBox.Show(detail, "Chi tiết đề thi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();
            lvQuizzes.Items.Clear();

            List<Quiz> allQuizzes = QuizManager.Instance.Quizzes;
            for (int i = 0; i < allQuizzes.Count; i++)
            {
                Quiz quiz = allQuizzes[i];
                if (quiz.Title.ToLower().Contains(searchText) || quiz.Description.ToLower().Contains(searchText))
                {
                    ListViewItem item = new ListViewItem(quiz.Title);
                    item.SubItems.Add(quiz.Description);
                    item.SubItems.Add(quiz.GetQuestionCount().ToString());
                    item.SubItems.Add(quiz.GetTotalPoints().ToString());
                    item.SubItems.Add(quiz.TimeLimit + " phút");
                    item.Tag = quiz;
                    lvQuizzes.Items.Add(item);
                }
            }
        }

        private void lvQuizzes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Có thể highlight hoặc enable/disable nút theo chọn item
        }

        private string PromptForString(string prompt, string title = "", string defaultValue = "")
        {
            Form form = new Form();
            form.Text = title;
            form.Width = 400;
            form.Height = 150;
            form.StartPosition = FormStartPosition.CenterParent;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.MaximizeBox = false;
            form.MinimizeBox = false;

            Label lbl = new Label();
            lbl.Text = prompt;
            lbl.Left = 20;
            lbl.Top = 20;
            lbl.Width = 350;
            form.Controls.Add(lbl);

            TextBox txt = new TextBox();
            txt.Left = 20;
            txt.Top = 50;
            txt.Width = 350;
            txt.Text = defaultValue;
            form.Controls.Add(txt);

            Button btnOk = new Button();
            btnOk.Text = "OK";
            btnOk.Left = 200;
            btnOk.Top = 90;
            btnOk.Width = 70;
            btnOk.DialogResult = DialogResult.OK;
            form.Controls.Add(btnOk);

            Button btnCancel = new Button();
            btnCancel.Text = "Hủy";
            btnCancel.Left = 280;
            btnCancel.Top = 90;
            btnCancel.Width = 70;
            btnCancel.DialogResult = DialogResult.Cancel;
            form.Controls.Add(btnCancel);

            form.AcceptButton = btnOk;
            form.CancelButton = btnCancel;

            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK) return txt.Text;
            return null;
        }
    }
}
