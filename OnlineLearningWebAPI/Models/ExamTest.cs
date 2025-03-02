using System;
using System.Collections.Generic;

namespace OnlineLearningWebAPI.Models;

public partial class ExamTest
{
    public int ExamTestId { get; set; }

    public int MoocId { get; set; }

    public string? TestName { get; set; }

    public int Duration { get; set; }

    public string CreatedBy { get; set; }

    public virtual Account CreatedByNavigation { get; set; } = null!;

    public virtual Mooc Mooc { get; set; } = null!;

    public virtual ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();
}
