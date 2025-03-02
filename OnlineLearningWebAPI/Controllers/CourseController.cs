using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineLearningWebAPI.DTOs.request.CourseRequest;
using OnlineLearningWebAPI.Service.IService;

namespace OnlineLearningWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("/api/Courses")]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null) return NotFound(new { message = "Course not found" });

            return Ok(course);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCourseDTO createCourseDTO)
        {
            var result = await _courseService.CreateCourseAsync(createCourseDTO);
            if (!result) return BadRequest(new { message = "Failed to create course" });

            return Ok(new { message = "Course created successfully" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] UpdateCourseDTO updateCourseDTO)
        {
            var result = await _courseService.UpdateCourseAsync(id, updateCourseDTO);
            if (!result) return NotFound(new { message = "Course not found or update failed" });

            return Ok(new { message = "Course updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var result = await _courseService.DeleteCourseAsync(id);
            if (!result) return NotFound(new { message = "Course not found or delete failed" });

            return Ok(new { message = "Course deleted successfully" });
        }

        [HttpPut("approve/{id}")]
        [Authorize(Policy = "RequireAdminRole")]
        public async Task<IActionResult> ApproveCourse(int id)
        {
            var result = await _courseService.ApproveCourseAsync(id);
            if (!result) return BadRequest(new { message = "Course not found or not pending" });

            return Ok(new { message = "Course approved successfully" });
        }
    }
}
