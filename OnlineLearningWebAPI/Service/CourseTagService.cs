using OnlineLearningWebAPI.DTOs.request.CourseTag;
using OnlineLearningWebAPI.DTOs.Response.CourseTagResponse;
using OnlineLearningWebAPI.Models;
using OnlineLearningWebAPI.Repository.IRepository;
using OnlineLearningWebAPI.Service.IService;

namespace OnlineLearningWebAPI.Service
{
    public class CourseTagService : ICourseTagService
    {
        private readonly ICourseTagRepository _courseTagRepository;

        public CourseTagService(ICourseTagRepository courseTagRepository)
        {
            _courseTagRepository = courseTagRepository;
        }

        public async Task<IEnumerable<CourseTagDTO>> GetTagsByCourseIdAsync(int courseId)
        {
            var tags = await _courseTagRepository.GetTagsByCourseIdAsync(courseId);
            return tags.Select(tag => new CourseTagDTO
            {
                CourseTagId = tag.CourseTagId,
                CourseId = tag.CourseId,
                TagName = tag.TagName
            });
        }

        public async Task<bool> CreateTagAsync(CreateCourseTagDTO createCourseTagDTO)
        {
            var courseTag = new CourseTag
            {
                CourseId = createCourseTagDTO.CourseId,
                TagName = createCourseTagDTO.TagName
            };

            await _courseTagRepository.AddAsync(courseTag);
            await _courseTagRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTagAsync(int courseTagId)
        {
            var tag = await _courseTagRepository.GetByIdAsync(courseTagId);
            if (tag == null) return false;

            _courseTagRepository.Delete(tag);
            await _courseTagRepository.SaveChangesAsync();
            return true;
        }
    }
}
