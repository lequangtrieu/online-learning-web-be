using Microsoft.AspNetCore.Mvc;
using OnlineLearningWebAPI.DTOs.FinalTestQuizRequest;
using OnlineLearningWebAPI.Service.IService;

namespace OnlineLearningWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinalTestQuizController : ControllerBase
    {
        private readonly IFinalTestQuizService _finalTestQuizService;

        public FinalTestQuizController(IFinalTestQuizService finalTestQuizService)
        {
            _finalTestQuizService = finalTestQuizService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFinalTestQuizzes()
        {
            var finalTestQuizzes = await _finalTestQuizService.GetAllFinalTestQuizzesAsync();
            return Ok(finalTestQuizzes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFinalTestQuizById(int id)
        {
            var finalTestQuiz = await _finalTestQuizService.GetFinalTestQuizByIdAsync(id);
            if (finalTestQuiz == null)
                return NotFound(new { Message = "Final Test Quiz not found" });

            return Ok(finalTestQuiz);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFinalTestQuiz([FromBody] CreateFinalTestQuizDTO createFinalTestQuizDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _finalTestQuizService.CreateFinalTestQuizAsync(createFinalTestQuizDTO);
            if (!result)
                return StatusCode(500, new { Message = "Failed to create Final Test Quiz" });

            return Ok(createFinalTestQuizDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFinalTestQuiz(int id)
        {
            var result = await _finalTestQuizService.DeleteFinalTestQuizAsync(id);
            if (!result)
                return NotFound(new { Message = "Final Test Quiz not found or delete failed" });

            return NoContent();
        }

        [HttpGet("FinalTest/{finalTestId}")]
        public async Task<IActionResult> GetFinalTestQuizzesByFinalTestId(int finalTestId)
        {
            var finalTestQuizzes = await _finalTestQuizService.GetFinalTestQuizzesByFinalTestIdAsync(finalTestId);
            return Ok(finalTestQuizzes);
        }
    }
}
