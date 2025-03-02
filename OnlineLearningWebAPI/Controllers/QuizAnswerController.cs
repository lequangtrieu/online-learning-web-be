using Microsoft.AspNetCore.Mvc;
using OnlineLearningWebAPI.DTOs.QuizAnswerRequest;
using OnlineLearningWebAPI.Service.IService;

namespace OnlineLearningWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizAnswerController : ControllerBase
    {
        private readonly IQuizAnswerService _quizAnswerService;

        public QuizAnswerController(IQuizAnswerService quizAnswerService)
        {
            _quizAnswerService = quizAnswerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAnswers()
        {
            var answers = await _quizAnswerService.GetAllAnswersAsync();
            return Ok(answers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnswerById(int id)
        {
            var answer = await _quizAnswerService.GetAnswerByIdAsync(id);
            if (answer == null)
                return NotFound(new { Message = "Answer not found" });

            return Ok(answer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnswer([FromBody] CreateQuizAnswerDTO createAnswerDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _quizAnswerService.CreateAnswerAsync(createAnswerDTO);
            if (!result)
                return StatusCode(500, new { Message = "Failed to create answer" });

            return Ok(createAnswerDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnswer(int id, [FromBody] UpdateQuizAnswerDTO updateAnswerDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _quizAnswerService.UpdateAnswerAsync(id, updateAnswerDTO);
            if (!result)
                return NotFound(new { Message = "Answer not found or update failed" });

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnswer(int id)
        {
            var result = await _quizAnswerService.DeleteAnswerAsync(id);
            if (!result)
                return NotFound(new { Message = "Answer not found or delete failed" });

            return NoContent();
        }

        [HttpGet("Quiz/{quizId}")]
        public async Task<IActionResult> GetAnswersByQuizId(int quizId)
        {
            var answers = await _quizAnswerService.GetAnswersByQuizIdAsync(quizId);
            return Ok(answers);
        }
    }
}
