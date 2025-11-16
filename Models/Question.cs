using System;
using System.Xml.Serialization;

namespace QuizApp.Models
{
    [XmlInclude(typeof(MultipleChoiceQuestion))]
    [XmlInclude(typeof(TrueFalseQuestion))]
    public abstract class Question
    {
        private string text;
        private int points;
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        public int Points
        {
            get { return points; }
            set { points = value; }
        }
        public Question()
        {
            text = string.Empty;
            points = 1;
        }
        public Question(string questionText, int pointValue)
        {
            text = questionText;
            points = pointValue;
        }
        public abstract bool CheckAnswer(string answer);
        public abstract string GetCorrectAnswer();
    }
}