using OnlineLearningWebAPI.Models;

namespace OnlineLearningWebAPI.Repository.IRepository
{
    public interface ICourseTagRepository : IRepository<CourseTag>
    {
        Task<IEnumerable<CourseTag>> GetTagsByCourseIdAsync(int courseId);
    }
}
