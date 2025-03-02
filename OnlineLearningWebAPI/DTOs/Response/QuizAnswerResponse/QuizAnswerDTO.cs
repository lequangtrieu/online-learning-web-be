namespace OnlineLearningWebAPI.DTOs.Response.QuizAnswerResponse
{
    public class QuizAnswerDTO
    {
        public int QuizAnswerId { get; set; }
        public int QuizId { get; set; }
        public string? Answer { get; set; }
        public bool? IsCorrect { get; set; }
    }
}
