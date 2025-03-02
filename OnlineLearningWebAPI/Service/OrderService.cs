using OnlineLearningWebAPI.Enum;
using OnlineLearningWebAPI.Models;
using OnlineLearningWebAPI.Repository.IRepository;
using OnlineLearningWebAPI.Service.IService;

namespace OnlineLearningWebAPI.Service
{
	public class OrderService : IOrderService
	{
		private readonly IOrderRepository _orderRepository;

		public OrderService(IOrderRepository orderRepository)
		{
			_orderRepository = orderRepository;
		}

		public async Task<bool> UpdateOrderStatusAsync(string orderCode, OrderStatus status)
		{
			if (!int.TryParse(orderCode, out int orderId))
			{
				return false;
			}

			var order = await _orderRepository.GetOrderByCodeAsync(orderId);

			if (order == null)
			{
				return false; // Không tìm thấy đơn hàng
			}

			// Cập nhật trạng thái Order
			order.Status = status;
			await _orderRepository.UpdateOrderAsync(order);
			return true;
		}

		public async Task<List<Order>> GetOrdersByUserIdAsync(string userId, OrderStatus status)
		{
			return await _orderRepository.GetOrdersByUserIdAsync(userId, status);
		}

		// Lấy đơn hàng theo Id
		public async Task<Order> GetOrderByIdAsync(int orderId)
		{
			return await _orderRepository.GetOrderByCodeAsync(orderId);
		}

		// Cập nhật đơn hàng
		public async Task UpdateOrderAsync(Order order)
		{
			await _orderRepository.UpdateOrderAsync(order);
		}
	}
}
