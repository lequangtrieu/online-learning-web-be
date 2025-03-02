using Net.payOS;
using Net.payOS.Types;
using OnlineLearningWebAPI.DTOs.request.PaymentRequest;
using OnlineLearningWebAPI.Enum;
using OnlineLearningWebAPI.Models;
using OnlineLearningWebAPI.Repository.IRepository;
using OnlineLearningWebAPI.Service.IService;

namespace OnlineLearningWebAPI.Service
{
	public class PaymentService : IPaymentService
	{
		private readonly PayOS _payOS;

		private readonly IOrderRepository _orderRepository;

		public PaymentService(PayOS payOS, IOrderRepository orderRepository)
		{
			_payOS = payOS;
			_orderRepository = orderRepository;
		}
		public async Task<string> CreatePaymentLink(CreatePaymentLinkRequest request)
		{
			// Tạo đối tượng Order
			var newOrder = new Order
			{
				UserId = request.UserId, // ID người dùng
				OrderName = request.OrderName,
				OrderDate = DateTime.UtcNow,
				TotalAmount = request.TotalPrice,
				PaymentMethod = request.PaymentMethod,
				Description = request.Description,
				Status = OrderStatus.Pending // Trạng thái ban đầu là Pending
			};

			// Lưu Order vào cơ sở dữ liệu
			await _orderRepository.AddAsync(newOrder);
			await _orderRepository.SaveChangesAsync();

			// Lấy OrderId vừa được tự động tạo
			int orderCode = newOrder.OrderId;

			// Chuẩn bị dữ liệu gửi yêu cầu tạo link thanh toán
			ItemData item = new ItemData(request.OrderName, 1, (int)request.TotalPrice);
			List<ItemData> items = new List<ItemData> { item };
			PaymentData paymentData = new PaymentData(orderCode, (int)request.TotalPrice, request.Description, items, request.cancelUrl, request.returnUrl);

			// Gửi yêu cầu tạo link thanh toán
			CreatePaymentResult response = await _payOS.createPaymentLink(paymentData);

			if (response == null || string.IsNullOrEmpty(response.checkoutUrl))
			{
				throw new Exception("Failed to create payment link");
			}

			// Trả về URL thanh toán
			return response.checkoutUrl;
		}


		//public async Task<IEnumerable<HistoryPayment>> GetPaymentHistory(string userId)
		//{
		//    return await _historyPaymentRepository.GetPaymentHistoryAsync(userId);
		//}

		//public async Task AddPaymentHistory(HistoryPayment historyPayment)
		//{
		//    await _historyPaymentRepository.AddPaymentHistoryAsync(historyPayment);
		//    await _historyPaymentRepository.SaveAsync();
		//}
	}
}
