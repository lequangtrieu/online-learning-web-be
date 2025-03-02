using OnlineLearningWebAPI.Models;

namespace OnlineLearningWebAPI.Repository.IRepository
{
    public interface ICertificateRepository
    {
        Task<IEnumerable<Certificate>> GetAllAsync();
        Task<Certificate?> GetByIdAsync(int id);
        Task AddAsync(Certificate certificate);
        void Update(Certificate certificate);
        void Delete(Certificate certificate);
        Task SaveChangesAsync();
    }
}
