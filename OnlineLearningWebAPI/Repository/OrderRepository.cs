using Microsoft.EntityFrameworkCore;
using OnlineLearningWebAPI.Data;
using OnlineLearningWebAPI.Enum;
using OnlineLearningWebAPI.Models;
using OnlineLearningWebAPI.Repository.IRepository;

namespace OnlineLearningWebAPI.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OnlineLearningDbContext _context;

        public OrderRepository(OnlineLearningDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Order order)
        {
            await _context.Set<Order>().AddAsync(order);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Order> GetOrderByCodeAsync(int orderCode)
        {
            return await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == orderCode);
        }

        public async Task UpdateOrderAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Order>> GetOrdersByUserIdAsync(string userId, OrderStatus status)
        {
            return await _context.Orders
                .Where(o => o.UserId.Equals(userId) && o.Status == status)
                .ToListAsync();
        }
    }
}
