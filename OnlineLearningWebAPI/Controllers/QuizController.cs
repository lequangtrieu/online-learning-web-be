using Microsoft.AspNetCore.Mvc;
using OnlineLearningWebAPI.DTOs.QuizRequest;
using OnlineLearningWebAPI.Service.IService;

namespace OnlineLearningWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizService _quizService;

        public QuizController(IQuizService quizService)
        {
            _quizService = quizService;
        }

        // GET: api/Quiz
        [HttpGet]
        public async Task<IActionResult> GetAllQuizzes()
        {
            var quizzes = await _quizService.GetAllQuizzesAsync();
            return Ok(quizzes);
        }

        // GET: api/Quiz/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuizById(int id)
        {
            var quiz = await _quizService.GetQuizByIdAsync(id);
            if (quiz == null)
                return NotFound(new { Message = "Quiz not found" });

            return Ok(quiz);
        }

        // POST: api/Quiz
        [HttpPost]
        public async Task<IActionResult> CreateQuiz([FromBody] CreateQuizDTO createQuizDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _quizService.CreateQuizAsync(createQuizDTO);
            if (!result)
                return StatusCode(500, new { Message = "Failed to create quiz" });

            return CreatedAtAction(nameof(GetQuizById), new { id = createQuizDTO.ExamTestId }, createQuizDTO);
        }

        // PUT: api/Quiz/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuiz(int id, [FromBody] UpdateQuizDTO updateQuizDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _quizService.UpdateQuizAsync(id, updateQuizDTO);
            if (!result)
                return NotFound(new { Message = "Quiz not found or update failed" });

            return NoContent();
        }

        // DELETE: api/Quiz/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuiz(int id)
        {
            var result = await _quizService.DeleteQuizAsync(id);
            if (!result)
                return NotFound(new { Message = "Quiz not found or delete failed" });

            return NoContent();
        }

        // GET: api/Quiz/ExamTest/{examTestId}
        [HttpGet("ExamTest/{examTestId}")]
        public async Task<IActionResult> GetQuizzesByExamTestId(int examTestId)
        {
            var quizzes = await _quizService.GetQuizzesByExamTestIdAsync(examTestId);
            return Ok(quizzes);
        }
    }
}
