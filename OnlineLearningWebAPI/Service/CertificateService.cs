using OnlineLearningWebAPI.DTOs.request.CertificateRequest;
using OnlineLearningWebAPI.DTOs.response.Certificate;
using OnlineLearningWebAPI.Models;
using OnlineLearningWebAPI.Repository.IRepository;
using OnlineLearningWebAPI.Service.IService;

namespace OnlineLearningWebAPI.Service
{
    public class CertificateService : ICertificateService
    {
        private readonly ICertificateRepository _certificateRepository;

        public CertificateService(ICertificateRepository certificateRepository)
        {
            _certificateRepository = certificateRepository;
        }

        public async Task<IEnumerable<CertificateDTO>> GetAllCertificatesAsync()
        {
            var certificates = await _certificateRepository.GetAllAsync();
            return certificates.Select(c => new CertificateDTO
            {
                CertificateId = c.CertificateId,
                Image = c.Image,
                CourseId = c.CourseId,
                AccountId = c.AccountId
            });
        }

        public async Task<CertificateDTO?> GetCertificateByIdAsync(int id)
        {
            var certificate = await _certificateRepository.GetByIdAsync(id);
            if (certificate == null) return null;

            return new CertificateDTO
            {
                CertificateId = certificate.CertificateId,
                Image = certificate.Image,
                CourseId = certificate.CourseId,
                AccountId = certificate.AccountId
            };
        }

        public async Task<bool> CreateCertificateAsync(CreateCertificateDTO createCertificateDTO)
        {
            var certificate = new Certificate
            {
                Image = createCertificateDTO.Image,
                CourseId = createCertificateDTO.CourseId,
                AccountId = createCertificateDTO.AccountId
            };

            await _certificateRepository.AddAsync(certificate);
            await _certificateRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateCertificateAsync(int id, UpdateCertificateDTO updateCertificateDTO)
        {
            var certificate = await _certificateRepository.GetByIdAsync(id);
            if (certificate == null) return false;

            certificate.Image = updateCertificateDTO.Image ?? certificate.Image;

            _certificateRepository.Update(certificate);
            await _certificateRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCertificateAsync(int id)
        {
            var certificate = await _certificateRepository.GetByIdAsync(id);
            if (certificate == null) return false;

            _certificateRepository.Delete(certificate);
            await _certificateRepository.SaveChangesAsync();
            return true;
        }
    }
}
