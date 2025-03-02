using OnlineLearningWebAPI.Models;

namespace OnlineLearningWebAPI.Repository.IRepository
{
    public interface ICourseEnrollmentRepository
    {
        Task<IEnumerable<CourseEnrollment>> GetAllAsync();
        Task<CourseEnrollment?> GetByIdAsync(int id);
        Task AddAsync(CourseEnrollment courseEnrollment);
        void Update(CourseEnrollment courseEnrollment);
        void Delete(CourseEnrollment courseEnrollment);
        Task SaveChangesAsync();
        Task<IEnumerable<CourseEnrollment>> GetEnrollmentsByCourseIdAsync(int courseId);
        Task<IEnumerable<CourseEnrollment>> GetEnrollmentsByAccountIdAsync(string accountId);
    }
}
