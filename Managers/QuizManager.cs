using System;
using System.Collections.Generic;
using QuizApp.Models;

namespace QuizApp.Managers
{
    /// <summary>
    /// Lớp quản lý toàn bộ quiz trong ứng dụng
    /// Sử dụng SINGLETON PATTERN - chỉ có 1 instance duy nhất
    /// </summary>
    public sealed class QuizManager
    {
        // Instance duy nhất (static readonly)
        private static readonly QuizManager instance = new QuizManager();

        // Danh sách các quiz
        private List<Quiz> quizzes;

        /// <summary>
        /// Constructor private - chỉ gọi được từ bên trong class
        /// Đảm bảo Singleton
        /// </summary>
        private QuizManager()
        {
            quizzes = new List<Quiz>();
        }

        /// <summary>
        /// Thuộc tính truy cập Instance duy nhất
        /// </summary>
        public static QuizManager Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Danh sách các quiz
        /// </summary>
        public List<Quiz> Quizzes
        {
            get { return quizzes; }
        }

        /// <summary>
        /// Thêm một quiz mới
        /// </summary>
        public void AddQuiz(Quiz quiz)
        {
            if (quiz != null)
            {
                quizzes.Add(quiz);
            }
        }

        /// <summary>
        /// Xóa một quiz
        /// </summary>
        public bool RemoveQuiz(Quiz quiz)
        {
            if (quiz == null) return false;
            return Quizzes.Remove(quiz);
        }


        /// <summary>
        /// Tìm quiz theo tiêu đề
        /// </summary>
        public Quiz FindQuizByTitle(string title)
        {
            foreach (Quiz q in quizzes)
            {
                if (q.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                {
                    return q;
                }
            }
            return null;
        }

        /// <summary>
        /// Lấy số lượng quiz
        /// </summary>
        public int GetQuizCount()
        {
            return quizzes.Count;
        }

        /// <summary>
        /// Xóa tất cả quiz
        /// </summary>
        public void ClearAllQuizzes()
        {
            quizzes.Clear();
        }

        /// <summary>
        /// Lấy danh sách tên các quiz
        /// </summary>
        public List<string> GetQuizTitles()
        {
            List<string> titles = new List<string>();
            foreach (Quiz q in quizzes)
            {
                titles.Add(q.Title);
            }
            return titles;
        }
    }
}