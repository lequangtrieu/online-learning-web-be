using Microsoft.EntityFrameworkCore;
using OnlineLearningWebAPI.Data;
using OnlineLearningWebAPI.Models;
using OnlineLearningWebAPI.Repository.IRepository;

namespace OnlineLearningWebAPI.Repository
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly OnlineLearningDbContext _context;

        public ScheduleRepository(OnlineLearningDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateScheduleAsync(Schedule schedule)
        {
            try
            {
                _context.Schedules.Add(schedule);
                await _context.SaveChangesAsync();
                return true;
            } catch
            {
                return true;
            }
        }

        public async Task<Schedule> GetScheduleByUserId(string UserId)
        {
            var result = await _context.Schedules.Where(x => x.UserID == UserId).FirstOrDefaultAsync();
            return result;
        }
    }
}
