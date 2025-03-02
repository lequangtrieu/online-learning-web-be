using OnlineLearningWebAPI.DTOs.QuizRequest;
using OnlineLearningWebAPI.DTOs.Response.QuizResponse;

namespace OnlineLearningWebAPI.Service.IService
{
    public interface IQuizService
    {
        Task<IEnumerable<QuizDTO>> GetAllQuizzesAsync();
        Task<QuizDTO?> GetQuizByIdAsync(int id);
        Task<bool> CreateQuizAsync(CreateQuizDTO createQuizDTO);
        Task<bool> UpdateQuizAsync(int id, UpdateQuizDTO updateQuizDTO);
        Task<bool> DeleteQuizAsync(int id);
        Task<IEnumerable<QuizDTO>> GetQuizzesByExamTestIdAsync(int examTestId);
    }
}