using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLearningWebAPI.DTOs.request.ScheduleRequest;
using OnlineLearningWebAPI.Service.IService;

namespace OnlineLearningWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpPost("create")]
        public async Task<bool> CreateSchedule(CreateScheduleRequest request)
        {
            var success = await _scheduleService.CreateSchedule(request);
            return success;
        }

        [HttpGet("get")]
        public async Task<string> GetSchedule(string UserId)
        {
            var schedule = await _scheduleService.GetSchedule(UserId);
            return schedule;
        }
    }
}
