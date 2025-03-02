using System;
using System.Collections.Generic;

namespace OnlineLearningWebAPI.Models;

public partial class Feedback
{
    public int FeedbackId { get; set; }

    public string AccountId { get; set; }

    public int CourseId { get; set; }

    public string? FeedbackText { get; set; }

    public int? Rating { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Course Course { get; set; } = null!;
}
