namespace OnlineLearningWebAPI.Models
{
    public class Profile
    {
        public int ProfileId { get; set; }
        public string? AccountId { get; set; }
        public string? UserName { get; set; }
        public string? Avatar { get; set; }
        public string? Address { get; set; }
        public bool? IsVIP { get; set; }
        public Account? Account { get; set; }
    }
}
