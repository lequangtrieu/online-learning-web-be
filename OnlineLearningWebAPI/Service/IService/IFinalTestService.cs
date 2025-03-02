using OnlineLearningWebAPI.DTOs.FinalTestRequest;
using OnlineLearningWebAPI.DTOs.Response.FinalTestResponse;

namespace OnlineLearningWebAPI.Service.IService
{
    public interface IFinalTestService
    {
        Task<IEnumerable<FinalTestDTO>> GetAllFinalTestsAsync();
        Task<FinalTestDTO?> GetFinalTestByIdAsync(int id);
        Task<bool> CreateFinalTestAsync(CreateFinalTestDTO createFinalTestDTO);
        Task<bool> UpdateFinalTestAsync(int id, UpdateFinalTestDTO updateFinalTestDTO);
        Task<bool> DeleteFinalTestAsync(int id);
        Task<IEnumerable<FinalTestDTO>> GetFinalTestsByCourseIdAsync(int courseId);
    }
}
