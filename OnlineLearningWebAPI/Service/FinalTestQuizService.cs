using OnlineLearningWebAPI.DTOs.FinalTestQuizRequest;
using OnlineLearningWebAPI.DTOs.Response.FinalTestQuizResponse;
using OnlineLearningWebAPI.Models;
using OnlineLearningWebAPI.Repository.IRepository;
using OnlineLearningWebAPI.Service.IService;

namespace OnlineLearningWebAPI.Service
{
    public class FinalTestQuizService : IFinalTestQuizService
    {
        private readonly IFinalTestQuizRepository _finalTestQuizRepository;

        public FinalTestQuizService(IFinalTestQuizRepository finalTestQuizRepository)
        {
            _finalTestQuizRepository = finalTestQuizRepository;
        }

        public async Task<IEnumerable<FinalTestQuizDTO>> GetAllFinalTestQuizzesAsync()
        {
            var finalTestQuizzes = await _finalTestQuizRepository.GetAllAsync();
            return finalTestQuizzes.Select(ftq => new FinalTestQuizDTO
            {
                FinalTestQuizId = ftq.FinalTestQuizId,
                FinalTestId = ftq.FinalTestId,
                QuizId = ftq.QuizId
            });
        }

        public async Task<FinalTestQuizDTO?> GetFinalTestQuizByIdAsync(int id)
        {
            var finalTestQuiz = await _finalTestQuizRepository.GetByIdAsync(id);
            if (finalTestQuiz == null) return null;

            return new FinalTestQuizDTO
            {
                FinalTestQuizId = finalTestQuiz.FinalTestQuizId,
                FinalTestId = finalTestQuiz.FinalTestId,
                QuizId = finalTestQuiz.QuizId
            };
        }

        public async Task<bool> CreateFinalTestQuizAsync(CreateFinalTestQuizDTO createFinalTestQuizDTO)
        {
            var finalTestQuiz = new FinalTestQuiz
            {
                FinalTestId = createFinalTestQuizDTO.FinalTestId,
                QuizId = createFinalTestQuizDTO.QuizId
            };

            await _finalTestQuizRepository.AddAsync(finalTestQuiz);
            await _finalTestQuizRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteFinalTestQuizAsync(int id)
        {
            var finalTestQuiz = await _finalTestQuizRepository.GetByIdAsync(id);
            if (finalTestQuiz == null) return false;

            _finalTestQuizRepository.Delete(finalTestQuiz);
            await _finalTestQuizRepository.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<FinalTestQuizDTO>> GetFinalTestQuizzesByFinalTestIdAsync(int finalTestId)
        {
            var finalTestQuizzes = await _finalTestQuizRepository.GetByFinalTestIdAsync(finalTestId);
            return finalTestQuizzes.Select(ftq => new FinalTestQuizDTO
            {
                FinalTestQuizId = ftq.FinalTestQuizId,
                FinalTestId = ftq.FinalTestId,
                QuizId = ftq.QuizId
            });
        }
    }
}
