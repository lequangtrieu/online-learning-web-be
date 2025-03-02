using Microsoft.EntityFrameworkCore;
using OnlineLearningWebAPI.DTOs;
using OnlineLearningWebAPI.DTOs.request.CourseCategoryRequest;
using OnlineLearningWebAPI.DTOs.Response.CourseCategoryResponse;
using OnlineLearningWebAPI.Models;
using OnlineLearningWebAPI.Repository.IRepository;
using OnlineLearningWebAPI.Service.IService;

namespace OnlineLearningWebAPI.Service
{
    public class CourseCategoryService : ICourseCategoryService
    {
        private readonly ICourseCategoryRepository _categoryRepository;

        public CourseCategoryService(ICourseCategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CourseCategoryDTO>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return categories.Select(c => new CourseCategoryDTO
            {
                CategoryId = c.CategoryId,
                Name = c.Name
            });
        }

        public async Task<CourseCategoryDTO?> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null) return null;

            return new CourseCategoryDTO
            {
                CategoryId = category.CategoryId,
                Name = category.Name
            };
        }

        public async Task<bool> CreateCategoryAsync(CreateCourseCategoryDTO createCategoryDTO)
        {
            var category = new CourseCategory
            {
                Name = createCategoryDTO.Name
            };

            await _categoryRepository.AddAsync(category);
            await _categoryRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateCategoryAsync(int id, UpdateCourseCategoryDTO updateCategoryDTO)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null) return false;

            category.Name = updateCategoryDTO.Name ?? category.Name;

            _categoryRepository.Update(category);
            await _categoryRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null) return false;

            _categoryRepository.Delete(category);
            await _categoryRepository.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CourseCategoryWithCoursesDTO>> GetCategoriesWithCoursesAsync()
        {
            var categories = await _categoryRepository.GetCategoriesWithCoursesAsync();
            return categories.Select(c => new CourseCategoryWithCoursesDTO
            {
                CategoryId = c.CategoryId,
                Name = c.Name,
                Courses = c.Courses.Select(course => new CourseDTO
                {
                    CourseId = course.CourseId,
                    CourseTitle = course.CourseTitle,
                    Description = course.Description
                }).ToList()
            });
        }
    }
}
