using QuizApp.Models;
using System;
using System.Collections.Generic;

public class Quiz
{
    private string title;
    private string description;
    private List<Question> questions;
    private int timeLimit;

    /// <summary>
    /// Đường dẫn file txt của đề thi
    /// </summary>
    public string FilePath { get; set; }

    public string Title
    {
        get { return title; }
        set { title = value; }
    }

    public string Description
    {
        get { return description; }
        set { description = value; }
    }

    public List<Question> Questions
    {
        get { return questions; }
        set { questions = value; }
    }

    public int TimeLimit
    {
        get { return timeLimit; }
        set { timeLimit = value; }
    }

    public event EventHandler QuizCompleted;
    public event EventHandler QuizStarted;

    public Quiz()
    {
        title = string.Empty;
        description = string.Empty;
        questions = new List<Question>();
        timeLimit = 30;
        FilePath = string.Empty; // mặc định rỗng
    }

    public Quiz(string quizTitle, string desc = "")
    {
        title = quizTitle;
        description = desc;
        questions = new List<Question>();
        timeLimit = 30;
        FilePath = string.Empty;
    }

    // Các phương thức khác giữ nguyên
    public void AddQuestion(Question q)
    {
        if (q != null) questions.Add(q);
    }

    public void RemoveQuestion(Question q)
    {
        if (questions.Contains(q)) questions.Remove(q);
    }

    public int GetQuestionCount()
    {
        return questions.Count;
    }

    public int GetTotalPoints()
    {
        int total = 0;
        foreach (Question q in questions)
        {
            total += q.Points;
        }
        return total;
    }

    public void Start()
    {
        OnQuizStarted(EventArgs.Empty);
    }

    public void Complete()
    {
        OnQuizCompleted(EventArgs.Empty);
    }

    protected virtual void OnQuizStarted(EventArgs e)
    {
        if (QuizStarted != null) QuizStarted(this, e);
    }

    protected virtual void OnQuizCompleted(EventArgs e)
    {
        if (QuizCompleted != null) QuizCompleted(this, e);
    }
}
