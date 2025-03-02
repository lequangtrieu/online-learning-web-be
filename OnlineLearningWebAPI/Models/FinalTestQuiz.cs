using System;
using System.Collections.Generic;

namespace OnlineLearningWebAPI.Models;

public partial class FinalTestQuiz
{
    public int FinalTestQuizId { get; set; }

    public int FinalTestId { get; set; }

    public int QuizId { get; set; }

    public virtual FinalTest FinalTest { get; set; } = null!;

    public virtual Quiz Quiz { get; set; } = null!;
}
