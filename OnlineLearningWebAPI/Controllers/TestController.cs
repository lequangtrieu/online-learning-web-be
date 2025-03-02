using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineLearningWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [Authorize(AuthenticationSchemes = "Bearer", Policy = "RequireAdminRole")]
        [HttpGet("ProtectedEndpoint")]
        public IActionResult GetProtectedData()
        {
            return Ok(new { Message = "This is a protected endpoint!" });
        }
        [HttpGet("Success")]
        public IActionResult Success()
        {
            return Ok(new { Message = "Success" });
        }
        [HttpGet("Fail")]
        public IActionResult Fail()
        {
            return Ok(new { Message = "Success" });
        }
    }
}
