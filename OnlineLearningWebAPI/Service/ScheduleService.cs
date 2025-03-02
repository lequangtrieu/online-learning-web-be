using OnlineLearningWebAPI.DTOs.request.ScheduleRequest;
using OnlineLearningWebAPI.Models;
using OnlineLearningWebAPI.Repository.IRepository;
using OnlineLearningWebAPI.Service.IService;

namespace OnlineLearningWebAPI.Service
{
	public class ScheduleService : IScheduleService
	{
		private readonly IOpenAIService _openAIService;
		private readonly IScheduleRepository _scheduleRepository;

		public ScheduleService(IOpenAIService openAIService,
			IScheduleRepository scheduleRepository)
		{
			_openAIService = openAIService;
			_scheduleRepository = scheduleRepository;
		}

		public async Task<bool> CreateSchedule(CreateScheduleRequest request)
		{
			try
			{
				var answer = await _openAIService.GetAnswer(request.Question);

				Schedule newSchedule = new Schedule()
				{
					ScheduleString = answer,
					UserID = request.UserId,
				};

				await _scheduleRepository.CreateScheduleAsync(newSchedule);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public async Task<string> GetSchedule(string UserId)
		{
			try
			{
				var answer = await _scheduleRepository.GetScheduleByUserId(UserId);
				if (answer != null)
				{
					return answer.ScheduleString;
				}
				return "";
			}
			catch
			{
				return "";
			}
		}
	}
}
