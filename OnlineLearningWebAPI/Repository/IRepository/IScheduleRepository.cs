using OnlineLearningWebAPI.Models;

namespace OnlineLearningWebAPI.Repository.IRepository
{
    public interface IScheduleRepository
    {
        Task<bool> CreateScheduleAsync(Schedule schedule);
        Task<Schedule> GetScheduleByUserId(string UserId);
    }
}
