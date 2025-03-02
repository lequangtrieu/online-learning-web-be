namespace OnlineLearningWebAPI.DTOs.Response.ExamTestResponse
{
    public class ExamTestDTO
    {
        public int ExamTestId { get; set; }
        public int MoocId { get; set; }
        public string? TestName { get; set; }
        public int Duration { get; set; }
        public string CreatedBy { get; set; }
    }
}
