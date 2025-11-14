using System;
using System.Collections.Generic;

namespace QuizApp.Models
{
    /// <summary>
    /// Lớp đại diện cho một đề thi
    /// Sử dụng EVENT và DELEGATE để thông báo khi hoàn thành
    /// </summary>
    public class Quiz
    {
        private string title;
        private string description;
        private List<Question> questions;
        private int timeLimit; // Giới hạn thời gian (phút)

        /// <summary>
        /// Tiêu đề đề thi
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        /// <summary>
        /// Mô tả đề thi
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        /// <summary>
        /// Danh sách câu hỏi
        /// Sử dụng GENERICS và COLLECTIONS
        /// </summary>
        public List<Question> Questions
        {
            get { return questions; }
            set { questions = value; }
        }

        /// <summary>
        /// Giới hạn thời gian (phút)
        /// </summary>
        public int TimeLimit
        {
            get { return timeLimit; }
            set { timeLimit = value; }
        }

        /// <summary>
        /// Event thông báo khi quiz hoàn thành
        /// Thể hiện OBSERVER PATTERN qua EVENT
        /// </summary>
        public event EventHandler QuizCompleted;

        /// <summary>
        /// Event thông báo khi bắt đầu quiz
        /// </summary>
        public event EventHandler QuizStarted;

        /// <summary>
        /// Constructor mặc định
        /// </summary>
        public Quiz()
        {
            title = string.Empty;
            description = string.Empty;
            questions = new List<Question>();
            timeLimit = 30;
        }

        /// <summary>
        /// Constructor với tham số
        /// </summary>
        public Quiz(string quizTitle, string desc = "")
        {
            title = quizTitle;
            description = desc;
            questions = new List<Question>();
            timeLimit = 30;
        }

        /// <summary>
        /// Thêm câu hỏi vào đề thi
        /// </summary>
        public void AddQuestion(Question q)
        {
            if (q != null)
            {
                questions.Add(q);
            }
        }

        /// <summary>
        /// Xóa câu hỏi khỏi đề thi
        /// </summary>
        public void RemoveQuestion(Question q)
        {
            if (questions.Contains(q))
            {
                questions.Remove(q);
            }
        }

        /// <summary>
        /// Lấy tổng số câu hỏi
        /// </summary>
        public int GetQuestionCount()
        {
            return questions.Count;
        }

        /// <summary>
        /// Lấy tổng điểm của đề thi
        /// </summary>
        public int GetTotalPoints()
        {
            int total = 0;
            foreach (Question q in questions)
            {
                total += q.Points;
            }
            return total;
        }

        /// <summary>
        /// Phương thức gọi khi bắt đầu quiz
        /// </summary>
        public void Start()
        {
            OnQuizStarted(EventArgs.Empty);
        }

        /// <summary>
        /// Phương thức gọi khi hoàn thành quiz
        /// </summary>
        public void Complete()
        {
            OnQuizCompleted(EventArgs.Empty);
        }

        /// <summary>
        /// Phương thức protected để phát sự kiện Started
        /// </summary>
        protected virtual void OnQuizStarted(EventArgs e)
        {
            if (QuizStarted != null)
            {
                QuizStarted(this, e);
            }
        }

        /// <summary>
        /// Phương thức protected để phát sự kiện Completed
        /// </summary>
        protected virtual void OnQuizCompleted(EventArgs e)
        {
            if (QuizCompleted != null)
            {
                QuizCompleted(this, e);
            }
        }
    }
}