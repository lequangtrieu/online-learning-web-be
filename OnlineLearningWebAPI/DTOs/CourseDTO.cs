namespace OnlineLearningWebAPI.DTOs
{
    public class CourseDTO
    {
        public int CourseId { get; set; }
        public string CourseTitle { get; set; } = null!;
        public string TeacherId { get; set; } = null!;
        public string? Description { get; set; }
        public string? Image { get; set; }
        public DateOnly? CreateDate { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string TeacherName { get; set; } = null!;
        public ICollection<string> Tags { get; set; } = new List<string>();
    }
}
