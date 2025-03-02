namespace OnlineLearningWebAPI.DTOs.FinalTestRequest
{
    public class UpdateFinalTestDTO
    {
        public string? TestName { get; set; }
        public int? Duration { get; set; }
        public bool? GeneratedFromExamTests { get; set; }
    }
}
