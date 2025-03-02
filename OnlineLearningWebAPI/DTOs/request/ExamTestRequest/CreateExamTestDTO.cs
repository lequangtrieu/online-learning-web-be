namespace OnlineLearningWebAPI.DTOs.ExamTestRequest
{
    public class CreateExamTestDTO
    {
        public int MoocId { get; set; }
        public string? TestName { get; set; }
        public int Duration { get; set; }
        public string CreatedBy { get; set; }
    }
}
