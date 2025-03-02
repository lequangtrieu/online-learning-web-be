//using Microsoft.EntityFrameworkCore;
//using OnlineLearningWebAPI.Data;
//using OnlineLearningWebAPI.Models;
//using OnlineLearningWebAPI.Repository.IRepository;

//namespace OnlineLearningWebAPI.Repository
//{
//    public class HistoryPaymentRepository : IHistoryPaymentRepository
//    {
//        private readonly OnlineLearningDbContext _dbContext;

//        public HistoryPaymentRepository(OnlineLearningDbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        public async Task<IEnumerable<HistoryPayment>> GetPaymentHistoryAsync(string userId)
//        {
//            return await _dbContext.HistoryPayment
//                .Where(h => h.UserId == userId)
//                .ToListAsync();
//        }

//        public async Task AddPaymentHistoryAsync(HistoryPayment historyPayment)
//        {
//            await _dbContext.HistoryPayment.AddAsync(historyPayment);
//        }

//        public async Task SaveAsync()
//        {
//            await _dbContext.SaveChangesAsync();
//        }
//    }
//}
