using Microsoft.EntityFrameworkCore;
using OnlineLearningWebAPI.Data;
using OnlineLearningWebAPI.Models;
using OnlineLearningWebAPI.Repository.IRepository;

namespace OnlineLearningWebAPI.Repository
{
    public class FinalTestQuizRepository : IFinalTestQuizRepository
    {
        private readonly OnlineLearningDbContext _context;

        public FinalTestQuizRepository(OnlineLearningDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FinalTestQuiz>> GetAllAsync()
        {
            return await _context.FinalTestQuizzes.ToListAsync();
        }

        public async Task<FinalTestQuiz?> GetByIdAsync(int id)
        {
            return await _context.FinalTestQuizzes
                .Include(ftq => ftq.FinalTest)
                .Include(ftq => ftq.Quiz)
                .FirstOrDefaultAsync(ftq => ftq.FinalTestQuizId == id);
        }

        public async Task AddAsync(FinalTestQuiz finalTestQuiz)
        {
            await _context.FinalTestQuizzes.AddAsync(finalTestQuiz);
        }

        public void Update(FinalTestQuiz finalTestQuiz)
        {
            _context.FinalTestQuizzes.Update(finalTestQuiz);
        }

        public void Delete(FinalTestQuiz finalTestQuiz)
        {
            _context.FinalTestQuizzes.Remove(finalTestQuiz);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<FinalTestQuiz>> GetByFinalTestIdAsync(int finalTestId)
        {
            return await _context.FinalTestQuizzes
                .Where(ftq => ftq.FinalTestId == finalTestId)
                .ToListAsync();
        }
    }
}
