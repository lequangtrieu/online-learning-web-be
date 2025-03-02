namespace OnlineLearningWebAPI.DTOs.request.CertificateRequest
{
    public class CreateCertificateDTO
    {
        public string? Image { get; set; }
        public int CourseId { get; set; }
        public string AccountId { get; set; }
    }
}
