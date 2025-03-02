namespace OnlineLearningWebAPI.DTOs.request.FeedbackRequest
{
    public class CreateFeedbackDTO
    {
        public string AccountId { get; set; }
        public int CourseId { get; set; }
        public string? FeedbackText { get; set; }
        public int? Rating { get; set; }
    }
}
