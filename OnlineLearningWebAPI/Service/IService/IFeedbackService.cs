using OnlineLearningWebAPI.DTOs;
using OnlineLearningWebAPI.DTOs.request.FeedbackRequest;
using OnlineLearningWebAPI.DTOs.response.Feedback;

namespace OnlineLearningWebAPI.Service.IService
{
    public interface IFeedbackService
    {
        Task<IEnumerable<FeedbackDTO>> GetAllFeedbacksAsync();
        Task<FeedbackDTO?> GetFeedbackByIdAsync(int id);
        Task<bool> CreateFeedbackAsync(CreateFeedbackDTO createFeedbackDTO);
        Task<bool> UpdateFeedbackAsync(int id, UpdateFeedbackDTO updateFeedbackDTO);
        Task<bool> DeleteFeedbackAsync(int id);
    }
}
