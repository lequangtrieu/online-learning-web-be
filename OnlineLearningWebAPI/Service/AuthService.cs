using OnlineLearningWebAPI.DTOs.request.AccountRequest;
using OnlineLearningWebAPI.Service.IService;

namespace OnlineLearningWebAPI.Service
{
    public class AuthService : IAuthService
    {
        public Task<(bool IsSuccess, string Token, string ErrorMessage)> LoginAsync(LoginRequest loginRequest)
        {
            throw new NotImplementedException();
        }

        public Task<(bool IsSuccess, string Message, string ErrorMessage)> RegisterAsync(RegisterRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<(bool IsSuccess, string Message)> ConfirmEmailAsync(string userId, string token)
        {
            throw new NotImplementedException();
        }

        public Task<(bool IsSuccess, string Message, string ErrorMessage)> ForgotPasswordAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<(bool IsSuccess, string Message, string ErrorMessage)> ResetPasswordAsync(string userId, string token, string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}
