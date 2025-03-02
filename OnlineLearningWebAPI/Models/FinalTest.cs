using System;
using System.Collections.Generic;

namespace OnlineLearningWebAPI.Models;

public partial class FinalTest
{
    public int FinalTestId { get; set; }

    public int CourseId { get; set; }

    public string? TestName { get; set; }

    public int Duration { get; set; }

    public bool? GeneratedFromExamTests { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual ICollection<FinalTestQuiz> FinalTestQuizzes { get; set; } = new List<FinalTestQuiz>();
}
