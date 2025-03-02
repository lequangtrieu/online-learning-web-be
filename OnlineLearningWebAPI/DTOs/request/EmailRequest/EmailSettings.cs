﻿namespace OnlineLearningWebAPI.DTOs.request.EmailRequest
{
    public class EmailSettings
    {
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string SenderEmail { get; set; }
        public string SenderPassword { get; set; }

        public override string ToString()
        {
            return $"SMTP Server: {SmtpServer}, Port: {SmtpPort}, Sender: {SenderEmail}";
        }
    }
}
