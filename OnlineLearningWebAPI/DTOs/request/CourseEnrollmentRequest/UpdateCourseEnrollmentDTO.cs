namespace OnlineLearningWebAPI.DTOs.request.CourseEnrollmentRequest
{
    public class UpdateCourseEnrollmentDTO
    {
        public int? ProgressPercentage { get; set; }
        public bool? IsCompleted { get; set; }
    }
}
