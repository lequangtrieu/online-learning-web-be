namespace OnlineLearningWebAPI.DTOs.QuizRequest
{
    public class CreateQuizDTO
    {
        public int ExamTestId { get; set; }
        public string? QuizName { get; set; }
        public string? QuizQuestion { get; set; }
        public int QuizTypeId { get; set; }
        public int MaxScore { get; set; }
    }
}
