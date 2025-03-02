namespace OnlineLearningWebAPI.DTOs.QuizAnswerRequest
{
    public class UpdateQuizAnswerDTO
    {
        public string? Answer { get; set; }
        public bool? IsCorrect { get; set; }
    }
}
