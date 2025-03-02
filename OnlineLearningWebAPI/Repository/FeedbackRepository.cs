using Microsoft.EntityFrameworkCore;
using OnlineLearningWebAPI.Data;
using OnlineLearningWebAPI.Models;
using OnlineLearningWebAPI.Repository.IRepository;

namespace OnlineLearningWebAPI.Repository
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly OnlineLearningDbContext _context;

        public FeedbackRepository(OnlineLearningDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Feedback>> GetAllAsync()
        {
            return await _context.Feedbacks.Include(f => f.Account).Include(f => f.Course).ToListAsync();
        }

        public async Task<Feedback?> GetByIdAsync(int id)
        {
            return await _context.Feedbacks.Include(f => f.Account).Include(f => f.Course)
                .FirstOrDefaultAsync(f => f.FeedbackId == id);
        }

        public async Task AddAsync(Feedback feedback)
        {
            await _context.Feedbacks.AddAsync(feedback);
        }

        public void Update(Feedback feedback)
        {
            _context.Feedbacks.Update(feedback);
        }

        public void Delete(Feedback feedback)
        {
            _context.Feedbacks.Remove(feedback);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}