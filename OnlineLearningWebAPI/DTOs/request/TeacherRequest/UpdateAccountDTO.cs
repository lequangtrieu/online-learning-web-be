using System.ComponentModel.DataAnnotations;

namespace OnlineLearningWebAPI.DTOs.request.TeacherRequest
{
    public class UpdateAccountDTO
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = null!;

        [StringLength(100, ErrorMessage = "UserName cannot exceed 100 characters")]
        public string? UserName { get; set; }

        public string? Avatar { get; set; } = null!;
        public bool? IsVip { get; set; }
    }
}
