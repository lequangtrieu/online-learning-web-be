using Microsoft.AspNetCore.Mvc;
using OnlineLearningWebAPI.DTOs;
using OnlineLearningWebAPI.DTOs.request.FeedbackRequest;
using OnlineLearningWebAPI.Service.IService;

namespace OnlineLearningWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFeedbacks()
        {
            var feedbacks = await _feedbackService.GetAllFeedbacksAsync();
            return Ok(feedbacks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeedbackById(int id)
        {
            var feedback = await _feedbackService.GetFeedbackByIdAsync(id);
            if (feedback == null) return NotFound(new { message = "Feedback not found" });

            return Ok(feedback);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeedback([FromBody] CreateFeedbackDTO createFeedbackDTO)
        {
            var result = await _feedbackService.CreateFeedbackAsync(createFeedbackDTO);
            if (!result) return BadRequest(new { message = "Failed to create feedback" });

            return Ok(new { message = "Feedback created successfully" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFeedback(int id, [FromBody] UpdateFeedbackDTO updateFeedbackDTO)
        {
            var result = await _feedbackService.UpdateFeedbackAsync(id, updateFeedbackDTO);
            if (!result) return NotFound(new { message = "Feedback not found or update failed" });

            return Ok(new { message = "Feedback updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedback(int id)
        {
            var result = await _feedbackService.DeleteFeedbackAsync(id);
            if (!result) return NotFound(new { message = "Feedback not found or delete failed" });

            return Ok(new { message = "Feedback deleted successfully" });
        }
    }
}
