using OnlineLearningWebAPI.DTOs.request.ScheduleRequest;

namespace OnlineLearningWebAPI.Service.IService
{
    public interface IScheduleService
    {
        Task<bool> CreateSchedule(CreateScheduleRequest theQuestion);
        Task<string> GetSchedule(string UserId);
    }
}
