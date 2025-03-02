namespace OnlineLearningWebAPI.DTOs.QuizAnswerRequest
{
    public class CreateQuizAnswerDTO
    {
        public int QuizId { get; set; }
        public string? Answer { get; set; }
        public bool? IsCorrect { get; set; }
    }
}
