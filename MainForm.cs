using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System;
using System.Windows.Forms;
using QuizApp.Managers;
using QuizApp.Models;

namespace QuizApp
{
    public partial class MainForm : Form
    {
        private XmlDataStore dataStore;
        private const string DATA_FILE = "quizzes.xml";

        public MainForm()
        {
            InitializeComponent();
            InitializeData();
        }

        /// <summary>
        /// Khởi tạo dữ liệu
        /// </summary>
        private void InitializeData()
        {
            dataStore = new XmlDataStore();

            try
            {
                // Thử load dữ liệu từ file
                if (dataStore.FileExists(DATA_FILE))
                {
                    dataStore.Load(DATA_FILE);
                    MessageBox.Show("Đã tải " + QuizManager.Instance.GetQuizCount() + " đề thi từ file!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Tạo dữ liệu mẫu
                    SampleDataGenerator.GenerateAllSampleData();
                    dataStore.Save(DATA_FILE);
                    MessageBox.Show("Đã tạo dữ liệu mẫu với " + QuizManager.Instance.GetQuizCount() + " đề thi!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadQuizList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi khởi tạo dữ liệu: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load danh sách quiz vào ComboBox
        /// </summary>
        private void LoadQuizList()
        {
            cmbQuizzes.Items.Clear();

            foreach (string title in QuizManager.Instance.GetQuizTitles())
            {
                cmbQuizzes.Items.Add(title);
            }

            if (cmbQuizzes.Items.Count > 0)
            {
                cmbQuizzes.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Hiển thị thông tin quiz được chọn
        /// </summary>
        private void cmbQuizzes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbQuizzes.SelectedIndex >= 0)
            {
                string selectedTitle = cmbQuizzes.SelectedItem.ToString();
                var quiz = QuizManager.Instance.FindQuizByTitle(selectedTitle);

                if (quiz != null)
                {
                    lblQuizInfo.Text = string.Format(
                        "Mô tả: {0}\nSố câu hỏi: {1}\nTổng điểm: {2}\nThời gian: {3} phút",
                        quiz.Description,
                        quiz.GetQuestionCount(),
                        quiz.GetTotalPoints(),
                        quiz.TimeLimit);
                }
            }
        }

        /// <summary>
        /// Bắt đầu làm bài
        /// </summary>
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (cmbQuizzes.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn một đề thi!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtStudentName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên của bạn!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStudentName.Focus();
                return;
            }

            string selectedTitle = cmbQuizzes.SelectedItem.ToString();
            Quiz quiz = QuizManager.Instance.FindQuizByTitle(selectedTitle);

            if (quiz != null)
            {
                // Mở form làm bài
                QuizForm quizForm = new QuizForm(quiz, txtStudentName.Text);
                this.Hide();
                quizForm.ShowDialog();
                this.Show();

                // Reload để cập nhật nếu có thay đổi
                txtStudentName.Clear();
            }
        }

        /// <summary>
        /// Xem kết quả
        /// </summary>
        private void btnViewResults_Click(object sender, EventArgs e)
        {
            ResultsForm resultsForm = new ResultsForm();
            resultsForm.ShowDialog();
        }

        /// <summary>
        /// Thoát chương trình
        /// </summary>
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn thoát?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Làm mới dữ liệu
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Bạn có muốn tạo lại dữ liệu mẫu không? (Dữ liệu cũ sẽ bị xóa)",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    QuizManager.Instance.ClearAllQuizzes();
                    SampleDataGenerator.GenerateAllSampleData();
                    dataStore.Save(DATA_FILE);
                    LoadQuizList();

                    MessageBox.Show("Đã làm mới dữ liệu!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblQuizInfo_Click(object sender, EventArgs e)
        {

        }
    }
}
