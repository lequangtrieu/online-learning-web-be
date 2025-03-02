using OnlineLearningWebAPI.DTOs.request.CourseTag;
using OnlineLearningWebAPI.DTOs.Response.CourseTagResponse;

namespace OnlineLearningWebAPI.Service.IService
{
    public interface ICourseTagService
    {
        Task<IEnumerable<CourseTagDTO>> GetTagsByCourseIdAsync(int courseId);
        Task<bool> CreateTagAsync(CreateCourseTagDTO createCourseTagDTO);
        Task<bool> DeleteTagAsync(int courseTagId);
    }
}
