using System;
using System.Collections.Generic;

namespace OnlineLearningWebAPI.Models;

public partial class Mooc
{
    public int MoocId { get; set; }

    public int CourseId { get; set; }

    public string? Image { get; set; }
    public string? Description { get; set; }


    public DateOnly? CreateDate { get; set; }

    public bool? IsPublic { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual ICollection<ExamTest> ExamTests { get; set; } = new List<ExamTest>();
}
