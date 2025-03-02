using Microsoft.AspNetCore.Mvc;
using OnlineLearningWebAPI.DTOs.ExamTestRequest;
using OnlineLearningWebAPI.Service.IService;

namespace OnlineLearningWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamTestController : ControllerBase
    {
        private readonly IExamTestService _examTestService;

        public ExamTestController(IExamTestService examTestService)
        {
            _examTestService = examTestService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExamTests()
        {
            var examTests = await _examTestService.GetAllExamTestsAsync();
            return Ok(examTests);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExamTestById(int id)
        {
            var examTest = await _examTestService.GetExamTestByIdAsync(id);
            if (examTest == null)
                return NotFound(new { Message = "Exam Test not found" });

            return Ok(examTest);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExamTest([FromBody] CreateExamTestDTO createExamTestDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _examTestService.CreateExamTestAsync(createExamTestDTO);
            if (!result)
                return StatusCode(500, new { Message = "Failed to create Exam Test" });

            return Ok(createExamTestDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExamTest(int id, [FromBody] UpdateExamTestDTO updateExamTestDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _examTestService.UpdateExamTestAsync(id, updateExamTestDTO);
            if (!result)
                return NotFound(new { Message = "Exam Test not found or update failed" });

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExamTest(int id)
        {
            var result = await _examTestService.DeleteExamTestAsync(id);
            if (!result)
                return NotFound(new { Message = "Exam Test not found or delete failed" });

            return NoContent();
        }

        [HttpGet("Mooc/{moocId}")]
        public async Task<IActionResult> GetExamTestsByMoocId(int moocId)
        {
            var examTests = await _examTestService.GetExamTestsByMoocIdAsync(moocId);
            return Ok(examTests);
        }
    }
}
