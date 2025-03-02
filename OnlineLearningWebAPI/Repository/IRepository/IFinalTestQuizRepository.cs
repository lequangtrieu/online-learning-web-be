using OnlineLearningWebAPI.Models;

namespace OnlineLearningWebAPI.Repository.IRepository
{
    public interface IFinalTestQuizRepository
    {
        Task<IEnumerable<FinalTestQuiz>> GetAllAsync();
        Task<FinalTestQuiz?> GetByIdAsync(int id);
        Task AddAsync(FinalTestQuiz finalTestQuiz);
        void Update(FinalTestQuiz finalTestQuiz);
        void Delete(FinalTestQuiz finalTestQuiz);
        Task SaveChangesAsync();
        Task<IEnumerable<FinalTestQuiz>> GetByFinalTestIdAsync(int finalTestId);
    }
}
