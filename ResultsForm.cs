using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QuizApp.Models;
using QuizApp.Managers;

namespace QuizApp
{
    public partial class ResultsForm : Form
    {
        private List<QuizResult> results;
        private XmlDataStore dataStore;

        public ResultsForm()
        {
            InitializeComponent();
            dataStore = new XmlDataStore();
            LoadResults();
        }

        private void LoadResults()
        {
            try
            {
                results = dataStore.LoadResults("results.xml");
                DisplayResults();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải kết quả: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayResults()
        {
            lvResults.Items.Clear();

            if (results.Count == 0)
            {
                MessageBox.Show("Chưa có kết quả nào!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (QuizResult result in results)
            {
                ListViewItem item = new ListViewItem(result.StudentName);
                item.SubItems.Add(result.QuizTitle);
                item.SubItems.Add(result.Score.Value.ToString());
                item.SubItems.Add(result.TotalQuestions.ToString());
                item.SubItems.Add(result.GetPercentage().ToString("F1") + "%");
                item.SubItems.Add(result.GetGrade());
                item.SubItems.Add(result.CompletedDate.ToString("dd/MM/yyyy HH:mm"));
                item.Tag = result;

                lvResults.Items.Add(item);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn xóa tất cả kết quả?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    results.Clear();
                    dataStore.SaveResults("results.xml", results);
                    DisplayResults();
                    MessageBox.Show("Đã xóa tất cả kết quả!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message,
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lvResults_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}