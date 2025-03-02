namespace OnlineLearningWebAPI.DTOs.Response.CourseEnrollmentResponse
{
    public class CourseEnrollmentDTO
    {
        public int CourseEnrollmentId { get; set; }
        public string AccountId { get; set; }
        public int CourseId { get; set; }
        public DateOnly? EnrollmentDate { get; set; }
        public int? ProgressPercentage { get; set; }
        public bool? IsCompleted { get; set; }
    }
}
