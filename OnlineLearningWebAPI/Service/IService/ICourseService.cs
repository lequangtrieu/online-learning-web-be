using OnlineLearningWebAPI.DTOs.request.CourseRequest;
using OnlineLearningWebAPI.DTOs.Response.CourseResponse;

namespace OnlineLearningWebAPI.Service.IService
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseDTO>> GetAllCoursesAsync();
        Task<CourseDTO?> GetCourseByIdAsync(int id);
        Task<bool> CreateCourseAsync(CreateCourseDTO createCourseDTO);
        Task<bool> UpdateCourseAsync(int id, UpdateCourseDTO updateCourseDTO);
        Task<bool> DeleteCourseAsync(int id);
        Task<IEnumerable<CourseDTO>> GetCoursesByTeacherIdAsync(string teacherId);
        Task<IEnumerable<CourseDTO>> GetCoursesByCategoryIdAsync(int categoryId);
        Task<bool> ApproveCourseAsync(int id);
    }
}
