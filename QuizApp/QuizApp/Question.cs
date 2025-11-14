using System;
using System.Xml.Serialization;

namespace QuizApp.Models
{
    /// <summary>
    /// Lớp trừu tượng đại diện cho một câu hỏi
    /// Thể hiện tính TRỪU TƯỢNG và ĐÓNG GÓI
    /// </summary>
    [XmlInclude(typeof(MultipleChoiceQuestion))]
    [XmlInclude(typeof(TrueFalseQuestion))]
    public abstract class Question
    {
        private string text;
        private int points;

        /// <summary>
        /// Nội dung câu hỏi
        /// </summary>
        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        /// <summary>
        /// Số điểm của câu hỏi
        /// </summary>
        public int Points
        {
            get { return points; }
            set { points = value; }
        }

        /// <summary>
        /// Constructor mặc định (cần cho XML Serialization)
        /// </summary>
        public Question()
        {
            text = string.Empty;
            points = 1;
        }

        /// <summary>
        /// Constructor có tham số
        /// </summary>
        public Question(string questionText, int pointValue)
        {
            text = questionText;
            points = pointValue;
        }

        /// <summary>
        /// Phương thức trừu tượng kiểm tra đáp án
        /// Thể hiện tính ĐA HÌNH - mỗi loại câu hỏi sẽ override khác nhau
        /// </summary>
        public abstract bool CheckAnswer(string answer);

        /// <summary>
        /// Phương thức trừu tượng lấy đáp án đúng (dùng để hiển thị)
        /// </summary>
        public abstract string GetCorrectAnswer();
    }
}