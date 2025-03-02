using OnlineLearningWebAPI.DTOs.request.AccountRequest;

namespace OnlineLearningWebAPI.Service.IService
{
    public interface IAuthService
    {
        Task<(bool IsSuccess, string Token, string ErrorMessage)> LoginAsync(LoginRequest loginRequest);
        Task<(bool IsSuccess, string Message, string ErrorMessage)> RegisterAsync(RegisterRequest request);
        Task<(bool IsSuccess, string Message)> ConfirmEmailAsync(string userId, string token);
        Task<(bool IsSuccess, string Message, string ErrorMessage)> ForgotPasswordAsync(string email);
        Task<(bool IsSuccess, string Message, string ErrorMessage)> ResetPasswordAsync(string userId, string token, string newPassword);
    }
}
