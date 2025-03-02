using OnlineLearningWebAPI.Models;

namespace OnlineLearningWebAPI.DTOs.request.ProfileRequest
{
    public class AddProfileRequest
    {
        public string? UserName { get; set; }
        public string? Avatar { get; set; }
        public string? Address { get; set; }
        public bool? IsVIP { get; set; } = false;
        public int AccountId { get; set; }
    }
}
