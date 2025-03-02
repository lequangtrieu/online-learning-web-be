using System;
using System.Collections.Generic;

namespace OnlineLearningWebAPI.Models;

public partial class QuizAnswer
{
    public int QuizAnswerId { get; set; }

    public int QuizId { get; set; }

    public string? Answer { get; set; }

    public bool? IsCorrect { get; set; }

    public virtual Quiz Quiz { get; set; } = null!;
}
