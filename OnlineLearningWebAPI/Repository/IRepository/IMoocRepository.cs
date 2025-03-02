using OnlineLearningWebAPI.Models;

namespace OnlineLearningWebAPI.Repository.IRepository;

public interface IMoocRepository
{
    Task<IEnumerable<Mooc>> GetAllAsync();
    Task<Mooc?> GetByIdAsync(int id);
    Task AddAsync(Mooc mooc);
    void Update(Mooc mooc);
    void Delete(Mooc mooc);
    Task SaveChangesAsync();
    Task<IEnumerable<Mooc>> GetMoocsByCourseIdAsync(int courseId);
}
