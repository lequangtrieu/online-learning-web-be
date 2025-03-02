using Microsoft.EntityFrameworkCore;
using OnlineLearningWebAPI.Data;
using OnlineLearningWebAPI.Models;
using OnlineLearningWebAPI.Repository.IRepository;

namespace OnlineLearningWebAPI.Repository
{
    public class ExamTestRepository : IExamTestRepository
    {
        private readonly OnlineLearningDbContext _context;

        public ExamTestRepository(OnlineLearningDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ExamTest>> GetAllAsync()
        {
            return await _context.ExamTests.ToListAsync();
        }

        public async Task<ExamTest?> GetByIdAsync(int id)
        {
            return await _context.ExamTests
                .Include(e => e.Quizzes)
                .FirstOrDefaultAsync(e => e.ExamTestId == id);
        }

        public async Task AddAsync(ExamTest examTest)
        {
            await _context.ExamTests.AddAsync(examTest);
        }

        public void Update(ExamTest examTest)
        {
            _context.ExamTests.Update(examTest);
        }

        public void Delete(ExamTest examTest)
        {
            _context.ExamTests.Remove(examTest);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ExamTest>> GetByMoocIdAsync(int moocId)
        {
            return await _context.ExamTests
                .Where(e => e.MoocId == moocId)
                .ToListAsync();
        }
    }
}
