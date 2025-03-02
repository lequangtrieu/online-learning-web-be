using OnlineLearningWebAPI.Models;

namespace OnlineLearningWebAPI.Repository.IRepository
{
    public interface IExamTestRepository
    {
        Task<IEnumerable<ExamTest>> GetAllAsync();
        Task<ExamTest?> GetByIdAsync(int id);
        Task AddAsync(ExamTest examTest);
        void Update(ExamTest examTest);
        void Delete(ExamTest examTest);
        Task SaveChangesAsync();
        Task<IEnumerable<ExamTest>> GetByMoocIdAsync(int moocId);
    }
}
