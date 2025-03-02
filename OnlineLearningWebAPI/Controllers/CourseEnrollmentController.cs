using Microsoft.AspNetCore.Mvc;
using OnlineLearningWebAPI.DTOs.request.CourseEnrollmentRequest;
using OnlineLearningWebAPI.Service.IService;

namespace OnlineLearningWebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourseEnrollmentController : ControllerBase
{
    private readonly ICourseEnrollmentService _enrollmentService;

    public CourseEnrollmentController(ICourseEnrollmentService enrollmentService)
    {
        _enrollmentService = enrollmentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllEnrollments()
    {
        var enrollments = await _enrollmentService.GetAllEnrollmentsAsync();
        return Ok(enrollments);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEnrollmentById(int id)
    {
        var enrollment = await _enrollmentService.GetEnrollmentByIdAsync(id);
        if (enrollment == null) return NotFound(new { message = "Enrollment not found" });

        return Ok(enrollment);
    }

    [HttpPost]
    public async Task<IActionResult> Enroll([FromBody] CreateCourseEnrollmentDTO createEnrollmentDTO)
    {
        var result = await _enrollmentService.EnrollAsync(createEnrollmentDTO);
        if (!result) return BadRequest(new { message = "Failed to enroll" });

        return Ok(new { message = "Enrollment created successfully" });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEnrollmentProgress(int id, [FromBody] UpdateCourseEnrollmentDTO updateEnrollmentDTO)
    {
        var result = await _enrollmentService.UpdateEnrollmentProgressAsync(id, updateEnrollmentDTO);
        if (!result) return NotFound(new { message = "Enrollment not found or update failed" });

        return Ok(new { message = "Enrollment updated successfully" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEnrollment(int id)
    {
        var result = await _enrollmentService.DeleteEnrollmentAsync(id);
        if (!result) return NotFound(new { message = "Enrollment not found or delete failed" });

        return Ok(new { message = "Enrollment deleted successfully" });
    }
}
