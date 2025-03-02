using OnlineLearningWebAPI.DTOs.request.CertificateRequest;
using OnlineLearningWebAPI.DTOs.response.Certificate;

namespace OnlineLearningWebAPI.Service.IService
{
    public interface ICertificateService
    {
        Task<IEnumerable<CertificateDTO>> GetAllCertificatesAsync();
        Task<CertificateDTO?> GetCertificateByIdAsync(int id);
        Task<bool> CreateCertificateAsync(CreateCertificateDTO createCertificateDTO);
        Task<bool> UpdateCertificateAsync(int id, UpdateCertificateDTO updateCertificateDTO);
        Task<bool> DeleteCertificateAsync(int id);
    }
}
