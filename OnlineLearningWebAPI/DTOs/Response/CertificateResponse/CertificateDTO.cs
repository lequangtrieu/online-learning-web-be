namespace OnlineLearningWebAPI.DTOs.response.Certificate
{
    public class CertificateDTO
    {
        public int CertificateId { get; set; }
        public string? Image { get; set; }
        public int CourseId { get; set; }
        public string AccountId { get; set; }
    }
}
