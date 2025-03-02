using OnlineLearningWebAPI.DTOs;
using OnlineLearningWebAPI.DTOs.response.QuizType;

namespace OnlineLearningWebAPI.Service.IService
{
    public interface IQuizTypeService
    {
        Task<IEnumerable<QuizTypeDTO>> GetAllQuizTypesAsync();
        Task<QuizTypeDTO?> GetQuizTypeByIdAsync(int id);
        Task<bool> CreateQuizTypeAsync(CreateQuizTypeDTO createQuizTypeDTO);
        Task<bool> UpdateQuizTypeAsync(int id, UpdateQuizTypeDTO updateQuizTypeDTO);
        Task<bool> DeleteQuizTypeAsync(int id);
    }
}
