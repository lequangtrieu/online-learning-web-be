using System;
using System.Collections.Generic;

namespace OnlineLearningWebAPI.Models;

public partial class Quiz
{
    public int QuizId { get; set; }

    public int ExamTestId { get; set; }

    public string? QuizName { get; set; }

    public string? QuizQuestion { get; set; }

    public int QuizTypeId { get; set; }

    public int MaxScore { get; set; }

    public virtual ExamTest ExamTest { get; set; } = null!;

    public virtual ICollection<FinalTestQuiz> FinalTestQuizzes { get; set; } = new List<FinalTestQuiz>();

    public virtual ICollection<QuizAnswer> QuizAnswers { get; set; } = new List<QuizAnswer>();

    public virtual QuizType QuizType { get; set; } = null!;
}
