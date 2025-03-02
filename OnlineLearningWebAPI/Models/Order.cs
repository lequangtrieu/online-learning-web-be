using OnlineLearningWebAPI.Enum;

namespace OnlineLearningWebAPI.Models
{
	public class Order
	{
		public int OrderId { get; set; }
		public string UserId { get; set; } = null!;
		public DateTime OrderDate { get; set; }
		public decimal TotalAmount { get; set; }
		public string PaymentMethod { get; set; }

		public string? OrderName { get; set; }

		public string? Description { get; set; }
		public OrderStatus Status { get; set; } = OrderStatus.Pending; // Giá trị mặc định là Pending

		public virtual Account User { get; set; } = null!;
		public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
	}
}
