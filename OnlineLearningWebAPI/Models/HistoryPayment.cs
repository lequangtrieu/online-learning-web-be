namespace OnlineLearningWebAPI.Models
{
    public class HistoryPayment
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public int CourseId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public virtual Account User { get; set; } = null!;
        public virtual Course Course { get; set; } = null!;
    }
}
