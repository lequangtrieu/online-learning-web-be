using System;
using System.Collections.Generic;

namespace OnlineLearningWebAPI.Models;

public partial class CourseTag
{
    public int CourseTagId { get; set; }

    public int CourseId { get; set; }

    public string? TagName { get; set; }

    public virtual Course Course { get; set; } = null!;
}
