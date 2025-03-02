using OnlineLearningWebAPI.Models;

namespace OnlineLearningWebAPI.Repository.IRepository
{
    public interface IQuizRepository
    {
        Task<IEnumerable<Quiz>> GetAllAsync();
        Task<Quiz?> GetByIdAsync(int id);
        Task AddAsync(Quiz quiz);
        void Update(Quiz quiz);
        void Delete(Quiz quiz);
        Task SaveChangesAsync();
        Task<IEnumerable<Quiz>> GetByExamTestIdAsync(int examTestId);
    }
}
