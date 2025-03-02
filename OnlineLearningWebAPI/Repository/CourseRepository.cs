using Microsoft.EntityFrameworkCore;
using OnlineLearningWebAPI.Data;
using OnlineLearningWebAPI.Enum;
using OnlineLearningWebAPI.Models;
using OnlineLearningWebAPI.Repository.IRepository;

namespace OnlineLearningWebAPI.Repository
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private readonly OnlineLearningDbContext _context;

        public CourseRepository(OnlineLearningDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetCoursesByTeacherIdAsync(string teacherId)
        {
            return await _context.Courses
                .Where(c => c.TeacherId == teacherId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetCoursesByCategoryIdAsync(int categoryId)
        {
            return await _context.Courses
                .Where(c => c.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<bool> UpdateStatusAsync(List<int> ids, CourseStatus status)
        {
            var effectRows = await _context.Courses.Where(x => ids.Contains(x.CourseId)).ExecuteUpdateAsync(x => x.SetProperty(c => c.Status, status));
            return effectRows > 0;
        }
    }
}
