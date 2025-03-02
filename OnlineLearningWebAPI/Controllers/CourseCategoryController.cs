using Microsoft.AspNetCore.Mvc;
using OnlineLearningWebAPI.DTOs.request.CourseCategoryRequest;
using OnlineLearningWebAPI.Service.IService;

namespace OnlineLearningWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseCategoryController : ControllerBase
    {
        private readonly ICourseCategoryService _categoryService;

        public CourseCategoryController(ICourseCategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null) return NotFound(new { message = "Category not found" });

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCourseCategoryDTO createCategoryDTO)
        {
            var result = await _categoryService.CreateCategoryAsync(createCategoryDTO);
            if (!result) return BadRequest(new { message = "Failed to create category" });

            return Ok(new { message = "Category created successfully" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] UpdateCourseCategoryDTO updateCategoryDTO)
        {
            var result = await _categoryService.UpdateCategoryAsync(id, updateCategoryDTO);
            if (!result) return NotFound(new { message = "Category not found or update failed" });

            return Ok(new { message = "Category updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _categoryService.DeleteCategoryAsync(id);
            if (!result) return NotFound(new { message = "Category not found or delete failed" });

            return Ok(new { message = "Category deleted successfully" });
        }

        [HttpGet("with-courses")]
        public async Task<IActionResult> GetCategoriesWithCourses()
        {
            var categories = await _categoryService.GetCategoriesWithCoursesAsync();
            return Ok(categories);
        }
    }
}
