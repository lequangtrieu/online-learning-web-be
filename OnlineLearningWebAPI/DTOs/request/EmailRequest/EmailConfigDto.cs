namespace OnlineLearningWebAPI.DTOs.request.EmailRequest
{
    public class EmailConfigDto
    {
        public string To { get; set; }       // Địa chỉ email nhận
        public string Subject { get; set; } // Tiêu đề email
        public string Body { get; set; }    // Nội dung email
        public bool IsHtml { get; set; }    // Email có định dạng HTML hay không
    }
}
