using Microsoft.EntityFrameworkCore;
using OnlineLearningWebAPI.Data;
using OnlineLearningWebAPI.Models;
using OnlineLearningWebAPI.Repository.IRepository;

namespace OnlineLearningWebAPI.Repository
{
    public class QuizRepository : IQuizRepository
    {
        private readonly OnlineLearningDbContext _context;

        public QuizRepository(OnlineLearningDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Quiz>> GetAllAsync()
        {
            return await _context.Quizzes.ToListAsync();
        }

        public async Task<Quiz?> GetByIdAsync(int id)
        {
            return await _context.Quizzes.FindAsync(id);
        }

        public async Task AddAsync(Quiz quiz)
        {
            await _context.Quizzes.AddAsync(quiz);
        }

        public void Update(Quiz quiz)
        {
            _context.Quizzes.Update(quiz);
        }

        public void Delete(Quiz quiz)
        {
            _context.Quizzes.Remove(quiz);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Quiz>> GetByExamTestIdAsync(int examTestId)
        {
            return await _context.Quizzes
                .Where(q => q.ExamTestId == examTestId)
                .ToListAsync();
        }
    }
}
