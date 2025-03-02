using Microsoft.EntityFrameworkCore;
using OnlineLearningWebAPI.Data;
using OnlineLearningWebAPI.Models;
using OnlineLearningWebAPI.Repository.IRepository;

namespace OnlineLearningWebAPI.Repository
{
    public class CertificateRepository : ICertificateRepository
    {
        private readonly OnlineLearningDbContext _context;

        public CertificateRepository(OnlineLearningDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Certificate>> GetAllAsync()
        {
            return await _context.Certificates.Include(c => c.Account).ToListAsync();
        }

        public async Task<Certificate?> GetByIdAsync(int id)
        {
            return await _context.Certificates.Include(c => c.Account)
                .FirstOrDefaultAsync(c => c.CertificateId == id);
        }

        public async Task AddAsync(Certificate certificate)
        {
            await _context.Certificates.AddAsync(certificate);
        }

        public void Update(Certificate certificate)
        {
            _context.Certificates.Update(certificate);
        }

        public void Delete(Certificate certificate)
        {
            _context.Certificates.Remove(certificate);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
