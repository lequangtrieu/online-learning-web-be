namespace OnlineLearningWebAPI.DTOs.Response.CourseTagResponse
{
    public class CourseTagDTO
    {
        public int CourseTagId { get; set; }
        public int CourseId { get; set; }
        public string? TagName { get; set; }
    }
}
