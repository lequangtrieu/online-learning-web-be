using OnlineLearningWebAPI.Enum;
using OnlineLearningWebAPI.Models;

namespace OnlineLearningWebAPI.Repository.IRepository
{
    public interface ICourseRepository: IRepository<Course>
    {
        Task<IEnumerable<Course>> GetCoursesByTeacherIdAsync(string teacherId);
        Task<IEnumerable<Course>> GetCoursesByCategoryIdAsync(int categoryId);
        Task<bool> UpdateStatusAsync(List<int> ids, CourseStatus status);
    }
}
