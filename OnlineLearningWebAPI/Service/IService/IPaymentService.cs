using OnlineLearningWebAPI.DTOs.request.PaymentRequest;

namespace OnlineLearningWebAPI.Service.IService
{
    public interface IPaymentService
    {
        Task<string> CreatePaymentLink(CreatePaymentLinkRequest request);
    }
}
