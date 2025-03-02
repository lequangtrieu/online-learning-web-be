using OnlineLearningWebAPI.Models;

namespace OnlineLearningWebAPI.Repository.IRepository
{
    public interface IFeedbackRepository
    {
        Task<IEnumerable<Feedback>> GetAllAsync();
        Task<Feedback?> GetByIdAsync(int id);
        Task AddAsync(Feedback feedback);
        void Update(Feedback feedback);
        void Delete(Feedback feedback);
        Task SaveChangesAsync();
    }
}
