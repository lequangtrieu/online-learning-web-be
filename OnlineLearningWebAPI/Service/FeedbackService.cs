using OnlineLearningWebAPI.DTOs;
using OnlineLearningWebAPI.DTOs.request.FeedbackRequest;
using OnlineLearningWebAPI.DTOs.response.Feedback;
using OnlineLearningWebAPI.Models;
using OnlineLearningWebAPI.Repository.IRepository;
using OnlineLearningWebAPI.Service.IService;

namespace OnlineLearningWebAPI.Service
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public async Task<IEnumerable<FeedbackDTO>> GetAllFeedbacksAsync()
        {
            var feedbacks = await _feedbackRepository.GetAllAsync();
            return feedbacks.Select(f => new FeedbackDTO
            {
                FeedbackId = f.FeedbackId,
                AccountId = f.AccountId,
                CourseId = f.CourseId,
                FeedbackText = f.FeedbackText,
                Rating = f.Rating
            });
        }

        public async Task<FeedbackDTO?> GetFeedbackByIdAsync(int id)
        {
            var feedback = await _feedbackRepository.GetByIdAsync(id);
            if (feedback == null) return null;

            return new FeedbackDTO
            {
                FeedbackId = feedback.FeedbackId,
                AccountId = feedback.AccountId,
                CourseId = feedback.CourseId,
                FeedbackText = feedback.FeedbackText,
                Rating = feedback.Rating
            };
        }

        public async Task<bool> CreateFeedbackAsync(CreateFeedbackDTO createFeedbackDTO)
        {
            var feedback = new Feedback
            {
                AccountId = createFeedbackDTO.AccountId,
                CourseId = createFeedbackDTO.CourseId,
                FeedbackText = createFeedbackDTO.FeedbackText,
                Rating = createFeedbackDTO.Rating
            };

            await _feedbackRepository.AddAsync(feedback);
            await _feedbackRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateFeedbackAsync(int id, UpdateFeedbackDTO updateFeedbackDTO)
        {
            var feedback = await _feedbackRepository.GetByIdAsync(id);
            if (feedback == null) return false;

            feedback.FeedbackText = updateFeedbackDTO.FeedbackText ?? feedback.FeedbackText;
            feedback.Rating = updateFeedbackDTO.Rating ?? feedback.Rating;

            _feedbackRepository.Update(feedback);
            await _feedbackRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteFeedbackAsync(int id)
        {
            var feedback = await _feedbackRepository.GetByIdAsync(id);
            if (feedback == null) return false;

            _feedbackRepository.Delete(feedback);
            await _feedbackRepository.SaveChangesAsync();
            return true;
        }
    }
}
