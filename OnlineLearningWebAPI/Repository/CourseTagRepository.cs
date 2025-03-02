using Microsoft.EntityFrameworkCore;
using OnlineLearningWebAPI.Data;
using OnlineLearningWebAPI.Models;
using OnlineLearningWebAPI.Repository.IRepository;

namespace OnlineLearningWebAPI.Repository
{
    public class CourseTagRepository : Repository<CourseTag>, ICourseTagRepository
    {
        private readonly OnlineLearningDbContext _context;

        public CourseTagRepository(OnlineLearningDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CourseTag>> GetTagsByCourseIdAsync(int courseId)
        {
            return await _context.CourseTags
                .Where(ct => ct.CourseId == courseId)
                .ToListAsync();
        }
    }
}
