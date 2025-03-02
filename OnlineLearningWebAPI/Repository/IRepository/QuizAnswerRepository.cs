using OnlineLearningWebAPI.Models;

namespace OnlineLearningWebAPI.Repository.IRepository
{
    public interface IQuizAnswerRepository
    {
        Task<IEnumerable<QuizAnswer>> GetAllAsync();
        Task<QuizAnswer?> GetByIdAsync(int id);
        Task AddAsync(QuizAnswer quizAnswer);
        void Update(QuizAnswer quizAnswer);
        void Delete(QuizAnswer quizAnswer);
        Task SaveChangesAsync();
        Task<IEnumerable<QuizAnswer>> GetAnswersByQuizIdAsync(int quizId);
    }
}
