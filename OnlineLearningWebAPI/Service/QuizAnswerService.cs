using OnlineLearningWebAPI.DTOs.QuizAnswerRequest;
using OnlineLearningWebAPI.DTOs.Response.QuizAnswerResponse;
using OnlineLearningWebAPI.Models;
using OnlineLearningWebAPI.Repository.IRepository;
using OnlineLearningWebAPI.Service.IService;

namespace OnlineLearningWebAPI.Service
{
    public class QuizAnswerService : IQuizAnswerService
    {
        private readonly IQuizAnswerRepository _quizAnswerRepository;

        public QuizAnswerService(IQuizAnswerRepository quizAnswerRepository)
        {
            _quizAnswerRepository = quizAnswerRepository;
        }

        public async Task<IEnumerable<QuizAnswerDTO>> GetAllAnswersAsync()
        {
            var answers = await _quizAnswerRepository.GetAllAsync();
            return answers.Select(a => new QuizAnswerDTO
            {
                QuizAnswerId = a.QuizAnswerId,
                QuizId = a.QuizId,
                Answer = a.Answer,
                IsCorrect = a.IsCorrect
            });
        }

        public async Task<QuizAnswerDTO?> GetAnswerByIdAsync(int id)
        {
            var answer = await _quizAnswerRepository.GetByIdAsync(id);
            if (answer == null) return null;

            return new QuizAnswerDTO
            {
                QuizAnswerId = answer.QuizAnswerId,
                QuizId = answer.QuizId,
                Answer = answer.Answer,
                IsCorrect = answer.IsCorrect
            };
        }

        public async Task<bool> CreateAnswerAsync(CreateQuizAnswerDTO createAnswerDTO)
        {
            var answer = new QuizAnswer
            {
                QuizId = createAnswerDTO.QuizId,
                Answer = createAnswerDTO.Answer,
                IsCorrect = createAnswerDTO.IsCorrect
            };

            await _quizAnswerRepository.AddAsync(answer);
            await _quizAnswerRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAnswerAsync(int id, UpdateQuizAnswerDTO updateAnswerDTO)
        {
            var answer = await _quizAnswerRepository.GetByIdAsync(id);
            if (answer == null) return false;

            answer.Answer = updateAnswerDTO.Answer ?? answer.Answer;
            answer.IsCorrect = updateAnswerDTO.IsCorrect ?? answer.IsCorrect;

            _quizAnswerRepository.Update(answer);
            await _quizAnswerRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAnswerAsync(int id)
        {
            var answer = await _quizAnswerRepository.GetByIdAsync(id);
            if (answer == null) return false;

            _quizAnswerRepository.Delete(answer);
            await _quizAnswerRepository.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<QuizAnswerDTO>> GetAnswersByQuizIdAsync(int quizId)
        {
            var answers = await _quizAnswerRepository.GetAnswersByQuizIdAsync(quizId);
            return answers.Select(a => new QuizAnswerDTO
            {
                QuizAnswerId = a.QuizAnswerId,
                QuizId = a.QuizId,
                Answer = a.Answer,
                IsCorrect = a.IsCorrect
            });
        }
    }
}
