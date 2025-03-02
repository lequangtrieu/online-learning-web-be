using OnlineLearningWebAPI.Models;

namespace OnlineLearningWebAPI.Repository.IRepository
{
    public interface IQuizTypeRepository
    {
        Task<IEnumerable<QuizType>> GetAllAsync();
        Task<QuizType?> GetByIdAsync(int id);
        Task AddAsync(QuizType quizType);
        void Update(QuizType quizType);
        void Delete(QuizType quizType);
        Task SaveChangesAsync();
    }
}
