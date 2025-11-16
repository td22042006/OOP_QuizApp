using System;

namespace QuizApp.Models
{
    /// <summary>
    /// Lớp lưu trữ kết quả bài thi
    /// </summary>
    public class QuizResult
    {
        private string studentName;
        private string quizTitle;
        private Score score;
        private int totalQuestions;
        private DateTime completedDate;
        private TimeSpan duration;

        /// <summary>
        /// Tên học sinh
        /// </summary>
        public string StudentName
        {
            get { return studentName; }
            set { studentName = value; }
        }

        /// <summary>
        /// Tiêu đề đề thi
        /// </summary>
        public string QuizTitle
        {
            get { return quizTitle; }
            set { quizTitle = value; }
        }

        /// <summary>
        /// Điểm số đạt được
        /// </summary>
        public Score Score
        {
            get { return score; }
            set { score = value; }
        }

        /// <summary>
        /// Tổng số câu hỏi
        /// </summary>
        public int TotalQuestions
        {
            get { return totalQuestions; }
            set { totalQuestions = value; }
        }

        /// <summary>
        /// Ngày hoàn thành
        /// </summary>
        public DateTime CompletedDate
        {
            get { return completedDate; }
            set { completedDate = value; }
        }

        /// <summary>
        /// Thời gian làm bài
        /// </summary>
        public TimeSpan Duration
        {
            get { return duration; }
            set { duration = value; }
        }

        /// <summary>
        /// Constructor mặc định
        /// </summary>
        public QuizResult()
        {
            studentName = string.Empty;
            quizTitle = string.Empty;
            score = new Score(0);
            totalQuestions = 0;
            completedDate = DateTime.Now;
            duration = TimeSpan.Zero;
        }

        /// <summary>
        /// Constructor đầy đủ
        /// </summary>
        public QuizResult(string name, string quiz, Score s, int total, TimeSpan time)
        {
            studentName = name;
            quizTitle = quiz;
            score = s;
            totalQuestions = total;
            completedDate = DateTime.Now;
            duration = time;
        }

        /// <summary>
        /// Tính phần trăm điểm
        /// </summary>
        public double GetPercentage()
        {
            if (totalQuestions == 0)
                return 0;

            return ((double)score.Value / (double)totalQuestions) * 100.0;
        }

        /// <summary>
        /// Lấy xếp loại
        /// </summary>
        public string GetGrade()
        {
            double percentage = GetPercentage();

            if (percentage >= 90)
                return "Xuất sắc";
            else if (percentage >= 80)
                return "Giỏi";
            else if (percentage >= 70)
                return "Khá";
            else if (percentage >= 50)
                return "Trung bình";
            else
                return "Yếu";
        }

        /// <summary>
        /// Override ToString
        /// </summary>
        public override string ToString()
        {
            return string.Format("{0} - {1}: {2}/{3} ({4:F1}%)",
                studentName, quizTitle, score.Value, totalQuestions, GetPercentage());
        }
    }
}