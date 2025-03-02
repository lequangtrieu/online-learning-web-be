using OnlineLearningWebAPI.DTOs.ExamTestRequest;
using OnlineLearningWebAPI.DTOs.Response.ExamTestResponse;

namespace OnlineLearningWebAPI.Service.IService
{
    public interface IExamTestService
    {
        Task<IEnumerable<ExamTestDTO>> GetAllExamTestsAsync();
        Task<ExamTestDTO?> GetExamTestByIdAsync(int id);
        Task<bool> CreateExamTestAsync(CreateExamTestDTO createExamTestDTO);
        Task<bool> UpdateExamTestAsync(int id, UpdateExamTestDTO updateExamTestDTO);
        Task<bool> DeleteExamTestAsync(int id);
        Task<IEnumerable<ExamTestDTO>> GetExamTestsByMoocIdAsync(int moocId);
    }
}
