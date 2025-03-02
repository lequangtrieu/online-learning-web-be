using System.ComponentModel.DataAnnotations;

namespace OnlineLearningWebAPI.DTOs.request.AccountRequest
{
    public class RegisterRequest
    {
        [Required]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu phải từ 6 ký tự trở lên.")]
        public string Password { get; set; }

        public string? Role { get; set; }
    }
}
