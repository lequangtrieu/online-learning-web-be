using OnlineLearningWebAPI.Models;

namespace OnlineLearningWebAPI.Repository.IRepository
{
    public interface ICourseCategoryRepository : IRepository<CourseCategory>
    {
        Task<IEnumerable<CourseCategory>> GetCategoriesWithCoursesAsync();
    }
}
