namespace OnlineLearningWebAPI.DTOs.Response.CourseCategoryResponse
{
    public class CourseCategoryWithCoursesDTO
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public List<CourseDTO> Courses { get; set; } = new List<CourseDTO>();
    }
}
