using Microsoft.EntityFrameworkCore;
using OnlineLearningWebAPI.Data;
using OnlineLearningWebAPI.Models;
using OnlineLearningWebAPI.Repository.IRepository;

namespace OnlineLearningWebAPI.Repository
{
    public class CourseCategoryRepository : Repository<CourseCategory>, ICourseCategoryRepository
    {
        private readonly OnlineLearningDbContext _context;

        public CourseCategoryRepository(OnlineLearningDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CourseCategory>> GetCategoriesWithCoursesAsync()
        {
            return await _context.CourseCategories
                .Include(cc => cc.Courses)
                .ToListAsync();
        }
    }
}
