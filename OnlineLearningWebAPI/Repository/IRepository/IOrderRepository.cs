using OnlineLearningWebAPI.Enum;
using OnlineLearningWebAPI.Models;

namespace OnlineLearningWebAPI.Repository.IRepository
{
    public interface IOrderRepository
    {
        Task AddAsync(Order order);
        Task SaveChangesAsync();
        Task<Order> GetOrderByCodeAsync(int orderCode);
        Task UpdateOrderAsync(Order order);
        Task<List<Order>> GetOrdersByUserIdAsync(string userId, OrderStatus status);
    }

}
