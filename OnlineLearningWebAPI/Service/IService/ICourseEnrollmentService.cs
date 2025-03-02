using OnlineLearningWebAPI.DTOs.request.CourseEnrollmentRequest;
using OnlineLearningWebAPI.DTOs.Response.CourseEnrollmentResponse;

namespace OnlineLearningWebAPI.Service.IService
{
    public interface ICourseEnrollmentService
    {
        Task<IEnumerable<CourseEnrollmentDTO>> GetAllEnrollmentsAsync();
        Task<CourseEnrollmentDTO?> GetEnrollmentByIdAsync(int id);
        Task<bool> EnrollAsync(CreateCourseEnrollmentDTO createEnrollmentDTO);
        Task<bool> UpdateEnrollmentProgressAsync(int id, UpdateCourseEnrollmentDTO updateEnrollmentDTO);
        Task<bool> DeleteEnrollmentAsync(int id);
        Task<IEnumerable<CourseEnrollmentDTO>> GetEnrollmentsByCourseIdAsync(int courseId);
        Task<IEnumerable<CourseEnrollmentDTO>> GetEnrollmentsByAccountIdAsync(string accountId);
    }
}
