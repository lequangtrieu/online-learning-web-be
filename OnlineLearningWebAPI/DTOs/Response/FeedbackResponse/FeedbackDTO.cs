namespace OnlineLearningWebAPI.DTOs.response.Feedback
{
    public class FeedbackDTO
    {
        public int FeedbackId { get; set; }
        public string AccountId { get; set; }
        public int CourseId { get; set; }
        public string? FeedbackText { get; set; }
        public int? Rating { get; set; }
    }
}
