using OnlineLearningWebAPI.DTOs;
using OnlineLearningWebAPI.DTOs.request.CourseCategoryRequest;
using OnlineLearningWebAPI.DTOs.Response.CourseCategoryResponse;

namespace OnlineLearningWebAPI.Service.IService
{
    public interface ICourseCategoryService
    {
        Task<IEnumerable<CourseCategoryDTO>> GetAllCategoriesAsync();
        Task<CourseCategoryDTO?> GetCategoryByIdAsync(int id);
        Task<bool> CreateCategoryAsync(CreateCourseCategoryDTO createCategoryDTO);
        Task<bool> UpdateCategoryAsync(int id, UpdateCourseCategoryDTO updateCategoryDTO);
        Task<bool> DeleteCategoryAsync(int id);
        Task<IEnumerable<CourseCategoryWithCoursesDTO>> GetCategoriesWithCoursesAsync();
    }
}
