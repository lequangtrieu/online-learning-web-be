namespace OnlineLearningWebAPI.DTOs.Response.FinalTestResponse
{
    public class FinalTestDTO
    {
        public int FinalTestId { get; set; }
        public int CourseId { get; set; }
        public string? TestName { get; set; }
        public int Duration { get; set; }
        public bool? GeneratedFromExamTests { get; set; }
    }
}
