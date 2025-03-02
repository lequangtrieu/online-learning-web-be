namespace OnlineLearningWebAPI.DTOs.request.MoocRequest
{
    public class CreateMoocDTO
    {
        public int CourseId { get; set; }
        public string? Description { get; set; }
        public DateOnly? CreateDate { get; set; }
        public bool? IsPublic { get; set; }
    }
}
