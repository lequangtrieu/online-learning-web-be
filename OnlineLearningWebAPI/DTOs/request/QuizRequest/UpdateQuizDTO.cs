namespace OnlineLearningWebAPI.DTOs.QuizRequest
{
    public class UpdateQuizDTO
    {
        public string? QuizName { get; set; }
        public string? QuizQuestion { get; set; }
        public int? MaxScore { get; set; }
    }
}
