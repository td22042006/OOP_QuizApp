using System;
using System.Collections.Generic;

namespace QuizApp.Models
{
    /// <summary>
    /// Lớp câu hỏi trắc nghiệm (nhiều lựa chọn)
    /// Thể hiện tính KẾ THỪA từ Question
    /// </summary>
    public class MultipleChoiceQuestion : Question
    {
        private List<string> choices;
        private int correctIndex;

        /// <summary>
        /// Danh sách các lựa chọn
        /// </summary>
        public List<string> Choices
        {
            get { return choices; }
            set { choices = value; }
        }

        /// <summary>
        /// Chỉ số đáp án đúng (0-based)
        /// </summary>
        public int CorrectIndex
        {
            get { return correctIndex; }
            set { correctIndex = value; }
        }

        /// <summary>
        /// Constructor mặc định
        /// </summary>
        public MultipleChoiceQuestion()
        {
            choices = new List<string>();
            correctIndex = 0;
        }

        /// <summary>
        /// Constructor đầy đủ
        /// </summary>
        public MultipleChoiceQuestion(string text, List<string> options, int correctIdx, int points = 1)
            : base(text, points)
        {
            choices = options;
            correctIndex = correctIdx;
        }

        /// <summary>
        /// Override phương thức kiểm tra đáp án
        /// Thể hiện tính ĐA HÌNH
        /// </summary>
        public override bool CheckAnswer(string answer)
        {
            if (string.IsNullOrEmpty(answer))
                return false;

            if (correctIndex >= 0 && correctIndex < choices.Count)
            {
                return answer.Trim().Equals(choices[correctIndex].Trim(), StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }

        /// <summary>
        /// Lấy đáp án đúng
        /// </summary>
        public override string GetCorrectAnswer()
        {
            if (correctIndex >= 0 && correctIndex < choices.Count)
            {
                return choices[correctIndex];
            }
            return string.Empty;
        }
    }
}