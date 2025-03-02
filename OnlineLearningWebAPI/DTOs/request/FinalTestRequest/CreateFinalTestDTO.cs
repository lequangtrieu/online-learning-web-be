namespace OnlineLearningWebAPI.DTOs.FinalTestRequest
{
    public class CreateFinalTestDTO
    {
        public int CourseId { get; set; }
        public string? TestName { get; set; }
        public int Duration { get; set; }
        public bool? GeneratedFromExamTests { get; set; }
    }
}
