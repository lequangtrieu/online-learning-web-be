using OnlineLearningWebAPI.DTOs.FinalTestQuizRequest;
using OnlineLearningWebAPI.DTOs.Response.FinalTestQuizResponse;

namespace OnlineLearningWebAPI.Service.IService
{
    public interface IFinalTestQuizService
    {
        Task<IEnumerable<FinalTestQuizDTO>> GetAllFinalTestQuizzesAsync();
        Task<FinalTestQuizDTO?> GetFinalTestQuizByIdAsync(int id);
        Task<bool> CreateFinalTestQuizAsync(CreateFinalTestQuizDTO createFinalTestQuizDTO);
        Task<bool> DeleteFinalTestQuizAsync(int id);
        Task<IEnumerable<FinalTestQuizDTO>> GetFinalTestQuizzesByFinalTestIdAsync(int finalTestId);
    }
}
