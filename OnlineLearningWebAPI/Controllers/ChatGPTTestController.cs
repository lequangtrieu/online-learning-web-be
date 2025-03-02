using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLearningWebAPI.Service.IService;

namespace OnlineLearningWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatGPTTestController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;

        public ChatGPTTestController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpGet("get-answer")]
        public async Task<IActionResult> GetAnswer(string question)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Error = "Invalid data" });
            }

            var OpenAIService = _serviceProvider.GetService<IOpenAIService>();

            string answer = await OpenAIService.GetAnswer(question);

            return Ok(new { Answer = answer });
        }

    }
}
