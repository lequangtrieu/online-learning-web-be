using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineLearningWebAPI.DTOs.request.TeacherRequest;
using OnlineLearningWebAPI.Service;

namespace OnlineLearningWebAPI.Controllers
{
    [Route("api/students")]
    [Controller]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: api/students/all
        [HttpGet("all")]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }

        // GET: api/students/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(string id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null) return NotFound(new { message = "[StudentService] | GetStudent | Student not found" });

            return Ok(student); 
        }

        // PUT: api/students/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(string id, [FromBody] UpdateAccountDTO studentDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var isUpdated = await _studentService.UpdateStudentDetailsAsync(id, studentDTO);
            if (!isUpdated) return NotFound(new { message = "[StudentService] | GetStudent | Student not found" });

            return NoContent();
        }
        [HttpPut("ban/{id}")]
        public async Task<IActionResult> BanStudent(string id)
        {

            var isUpdated = await _studentService.BanStudentAsync(id);
            if (!isUpdated) return NotFound(new { message = "[StudentService] | GetStudent | Student not found" });

            return NoContent();
        }

        [HttpPut("unban/{id}")]
        public async Task<IActionResult> UnbanStudent(string id)
        {

            var isUpdated = await _studentService.UnbanStudentAsync(id);
            if (!isUpdated) return NotFound(new { message = "[StudentService] | GetStudent | Student not found" });

            return NoContent();
        }
    }
}
