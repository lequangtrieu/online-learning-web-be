using OnlineLearningWebAPI.Enum;

namespace OnlineLearningWebAPI.DTOs.request.CourseRequest
{
    public class UpdateCourseDTO
    {
        public string? CourseTitle { get; set; }
        public string? Description { get; set; }
        public string TeacherId { get; set; } = null!;
        public int? CategoryId { get; set; }
        public int Price { get; set; }
        public string ImageURL { get; set; }
        public CourseStatus Status { get; set; }
    }
}
