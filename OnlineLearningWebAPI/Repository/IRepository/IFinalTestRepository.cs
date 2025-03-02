using OnlineLearningWebAPI.Models;

namespace OnlineLearningWebAPI.Repository.IRepository
{
    public interface IFinalTestRepository
    {
        Task<IEnumerable<FinalTest>> GetAllAsync();
        Task<FinalTest?> GetByIdAsync(int id);
        Task AddAsync(FinalTest finalTest);
        void Update(FinalTest finalTest);
        void Delete(FinalTest finalTest);
        Task SaveChangesAsync();
        Task<IEnumerable<FinalTest>> GetByCourseIdAsync(int courseId);
    }
}
