namespace OnlineLearningWebAPI.DTOs.request.CourseEnrollmentRequest
{
    public class CreateCourseEnrollmentDTO
    {
        public string AccountId { get; set; } = null!;
        public int CourseId { get; set; }
        public DateOnly? EnrollmentDate { get; set; }
        public int? ProgressPercentage { get; set; }
        public bool? IsCompleted { get; set; }
    }
}
