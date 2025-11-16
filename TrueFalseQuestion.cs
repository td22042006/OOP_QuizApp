using System;

namespace QuizApp.Models
{
    /// <summary>
    /// Lớp câu hỏi Đúng/Sai
    /// Thể hiện tính KẾ THỪA từ Question
    /// </summary>
    public class TrueFalseQuestion : Question
    {
        private bool correctAnswer;

        /// <summary>
        /// Đáp án đúng (true hoặc false)
        /// </summary>
        public bool CorrectAnswer
        {
            get { return correctAnswer; }
            set { correctAnswer = value; }
        }

        /// <summary>
        /// Constructor mặc định
        /// </summary>
        public TrueFalseQuestion()
        {
            correctAnswer = true;
        }

        /// <summary>
        /// Constructor đầy đủ
        /// </summary>
        public TrueFalseQuestion(string text, bool correct, int points = 1)
            : base(text, points)
        {
            correctAnswer = correct;
        }

        /// <summary>
        /// Override phương thức kiểm tra đáp án
        /// Thể hiện tính ĐA HÌNH
        /// </summary>
        public override bool CheckAnswer(string answer)
        {
            if (string.IsNullOrEmpty(answer))
                return false;

            bool userAnswer;
            string lowerAnswer = answer.ToLower().Trim();

            if (lowerAnswer == "true" || lowerAnswer == "đúng")
            {
                userAnswer = true;
            }
            else if (lowerAnswer == "false" || lowerAnswer == "sai")
            {
                userAnswer = false;
            }
            else
            {
                return false;
            }

            return userAnswer == correctAnswer;
        }

        /// <summary>
        /// Lấy đáp án đúng
        /// </summary>
        public override string GetCorrectAnswer()
        {
            return correctAnswer ? "Đúng" : "Sai";
        }
    }
}