using Microsoft.EntityFrameworkCore;
using OnlineLearningWebAPI.Data;
using OnlineLearningWebAPI.Models;
using OnlineLearningWebAPI.Repository.IRepository;

namespace OnlineLearningWebAPI.Repository
{
    public class FinalTestRepository : IFinalTestRepository
    {
        private readonly OnlineLearningDbContext _context;

        public FinalTestRepository(OnlineLearningDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FinalTest>> GetAllAsync()
        {
            return await _context.FinalTests.ToListAsync();
        }

        public async Task<FinalTest?> GetByIdAsync(int id)
        {
            return await _context.FinalTests
                .Include(ft => ft.FinalTestQuizzes)
                .FirstOrDefaultAsync(ft => ft.FinalTestId == id);
        }

        public async Task AddAsync(FinalTest finalTest)
        {
            await _context.FinalTests.AddAsync(finalTest);
        }

        public void Update(FinalTest finalTest)
        {
            _context.FinalTests.Update(finalTest);
        }

        public void Delete(FinalTest finalTest)
        {
            _context.FinalTests.Remove(finalTest);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<FinalTest>> GetByCourseIdAsync(int courseId)
        {
            return await _context.FinalTests
                .Where(ft => ft.CourseId == courseId)
                .ToListAsync();
        }
    }
}
