using Microsoft.AspNetCore.Identity;

namespace OnlineLearningWebAPI.Models;

public partial class Account : IdentityUser
{
    public string? Avatar { get; set; }

    public bool? IsBan { get; set; }

    public bool? IsVip { get; set; }

    public virtual ICollection<ActivityLog> ActivityLogs { get; set; } = new List<ActivityLog>();

    public virtual ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();

    public virtual ICollection<CourseEnrollment> CourseEnrollments { get; set; } = new List<CourseEnrollment>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<ExamTest> ExamTests { get; set; } = new List<ExamTest>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public Profile? Profile { get; set; }
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
