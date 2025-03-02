using Microsoft.EntityFrameworkCore;
using OnlineLearningWebAPI.Data;
using OnlineLearningWebAPI.Models;
using OnlineLearningWebAPI.Repository.IRepository;

namespace OnlineLearningWebAPI.Repository
{
    public class QuizTypeRepository : IQuizTypeRepository
    {
        private readonly OnlineLearningDbContext _context;

        public QuizTypeRepository(OnlineLearningDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<QuizType>> GetAllAsync()
        {
            return await _context.QuizTypes.Include(q => q.Quizzes).ToListAsync();
        }

        public async Task<QuizType?> GetByIdAsync(int id)
        {
            return await _context.QuizTypes.Include(q => q.Quizzes)
                .FirstOrDefaultAsync(q => q.QuizTypeId == id);
        }

        public async Task AddAsync(QuizType quizType)
        {
            await _context.QuizTypes.AddAsync(quizType);
        }

        public void Update(QuizType quizType)
        {
            _context.QuizTypes.Update(quizType);
        }

        public void Delete(QuizType quizType)
        {
            _context.QuizTypes.Remove(quizType);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
