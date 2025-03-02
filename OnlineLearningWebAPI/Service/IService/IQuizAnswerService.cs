using OnlineLearningWebAPI.DTOs.QuizAnswerRequest;
using OnlineLearningWebAPI.DTOs.Response.QuizAnswerResponse;

namespace OnlineLearningWebAPI.Service.IService
{
    public interface IQuizAnswerService
    {
        Task<IEnumerable<QuizAnswerDTO>> GetAllAnswersAsync();
        Task<QuizAnswerDTO?> GetAnswerByIdAsync(int id);
        Task<bool> CreateAnswerAsync(CreateQuizAnswerDTO createAnswerDTO);
        Task<bool> UpdateAnswerAsync(int id, UpdateQuizAnswerDTO updateAnswerDTO);
        Task<bool> DeleteAnswerAsync(int id);
        Task<IEnumerable<QuizAnswerDTO>> GetAnswersByQuizIdAsync(int quizId);
    }
}
