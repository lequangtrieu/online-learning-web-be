using Microsoft.AspNetCore.Mvc;
using OnlineLearningWebAPI.DTOs;
using OnlineLearningWebAPI.Service.IService;

namespace OnlineLearningWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizTypeController : ControllerBase
    {
        private readonly IQuizTypeService _quizTypeService;

        public QuizTypeController(IQuizTypeService quizTypeService)
        {
            _quizTypeService = quizTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuizTypes()
        {
            var quizTypes = await _quizTypeService.GetAllQuizTypesAsync();
            return Ok(quizTypes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuizTypeById(int id)
        {
            var quizType = await _quizTypeService.GetQuizTypeByIdAsync(id);
            if (quizType == null) return NotFound(new { message = "Quiz type not found" });

            return Ok(quizType);
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuizType([FromBody] CreateQuizTypeDTO createQuizTypeDTO)
        {
            var result = await _quizTypeService.CreateQuizTypeAsync(createQuizTypeDTO);
            if (!result) return BadRequest(new { message = "Failed to create quiz type" });

            return Ok(new { message = "Quiz type created successfully" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuizType(int id, [FromBody] UpdateQuizTypeDTO updateQuizTypeDTO)
        {
            var result = await _quizTypeService.UpdateQuizTypeAsync(id, updateQuizTypeDTO);
            if (!result) return NotFound(new { message = "Quiz type not found or update failed" });

            return Ok(new { message = "Quiz type updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuizType(int id)
        {
            var result = await _quizTypeService.DeleteQuizTypeAsync(id);
            if (!result) return NotFound(new { message = "Quiz type not found or delete failed" });

            return Ok(new { message = "Quiz type deleted successfully" });
        }
    }
}
