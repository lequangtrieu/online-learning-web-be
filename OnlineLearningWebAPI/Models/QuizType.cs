using System;
using System.Collections.Generic;

namespace OnlineLearningWebAPI.Models;

public partial class QuizType
{
    public int QuizTypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();
}
