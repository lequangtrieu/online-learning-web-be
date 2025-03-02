using Microsoft.EntityFrameworkCore;
using OnlineLearningWebAPI.Data;
using OnlineLearningWebAPI.Models;
using OnlineLearningWebAPI.Repository.IRepository;

namespace OnlineLearningWebAPI.Repository
{
    public class QuizAnswerRepository : IQuizAnswerRepository
    {
        private readonly OnlineLearningDbContext _context;

        public QuizAnswerRepository(OnlineLearningDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<QuizAnswer>> GetAllAsync()
        {
            return await _context.QuizAnswers.ToListAsync();
        }

        public async Task<QuizAnswer?> GetByIdAsync(int id)
        {
            return await _context.QuizAnswers.FindAsync(id);
        }

        public async Task AddAsync(QuizAnswer quizAnswer)
        {
            await _context.QuizAnswers.AddAsync(quizAnswer);
        }

        public void Update(QuizAnswer quizAnswer)
        {
            _context.QuizAnswers.Update(quizAnswer);
        }

        public void Delete(QuizAnswer quizAnswer)
        {
            _context.QuizAnswers.Remove(quizAnswer);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<QuizAnswer>> GetAnswersByQuizIdAsync(int quizId)
        {
            return await _context.QuizAnswers
                .Where(a => a.QuizId == quizId)
                .ToListAsync();
        }
    }
}
