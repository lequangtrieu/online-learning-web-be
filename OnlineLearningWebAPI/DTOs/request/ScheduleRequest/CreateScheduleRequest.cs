namespace OnlineLearningWebAPI.DTOs.request.ScheduleRequest
{
    public class CreateScheduleRequest
    {
        public string UserId { get; set; } = default!;
        public string Question { get; set; } = default!;
    }
}
