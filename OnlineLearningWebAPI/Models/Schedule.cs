namespace OnlineLearningWebAPI.Models
{
    public class Schedule
    {
        public int ScheduleId { get; set; }
        public string UserID { get; set; } = default!;
        public string ScheduleString { get; set; } = default!;
    }
}
