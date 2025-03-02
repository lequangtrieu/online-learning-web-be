using Microsoft.AspNetCore.Mvc;
using OnlineLearningWebAPI.DTOs.FinalTestRequest;
using OnlineLearningWebAPI.Service.IService;

namespace OnlineLearningWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinalTestController : ControllerBase
    {
        private readonly IFinalTestService _finalTestService;

        public FinalTestController(IFinalTestService finalTestService)
        {
            _finalTestService = finalTestService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFinalTests()
        {
            var finalTests = await _finalTestService.GetAllFinalTestsAsync();
            return Ok(finalTests);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFinalTestById(int id)
        {
            var finalTest = await _finalTestService.GetFinalTestByIdAsync(id);
            if (finalTest == null)
                return NotFound(new { Message = "Final Test not found" });

            return Ok(finalTest);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFinalTest([FromBody] CreateFinalTestDTO createFinalTestDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _finalTestService.CreateFinalTestAsync(createFinalTestDTO);
            if (!result)
                return StatusCode(500, new { Message = "Failed to create Final Test" });

            return Ok(createFinalTestDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFinalTest(int id, [FromBody] UpdateFinalTestDTO updateFinalTestDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _finalTestService.UpdateFinalTestAsync(id, updateFinalTestDTO);
            if (!result)
                return NotFound(new { Message = "Final Test not found or update failed" });

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFinalTest(int id)
        {
            var result = await _finalTestService.DeleteFinalTestAsync(id);
            if (!result)
                return NotFound(new { Message = "Final Test not found or delete failed" });

            return NoContent();
        }

        [HttpGet("Course/{courseId}")]
        public async Task<IActionResult> GetFinalTestsByCourseId(int courseId)
        {
            var finalTests = await _finalTestService.GetFinalTestsByCourseIdAsync(courseId);
            return Ok(finalTests);
        }
    }
}
