using OnlineLearningWebAPI.Models;

namespace OnlineLearningWebAPI.Repository.IRepository
{
    public interface IHistoryPaymentRepository
    {
        Task<IEnumerable<HistoryPayment>> GetPaymentHistoryAsync(string userId);
        Task AddPaymentHistoryAsync(HistoryPayment historyPayment);
        Task SaveAsync();
    }
}
