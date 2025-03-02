using OnlineLearningWebAPI.DTOs;
using OnlineLearningWebAPI.DTOs.response.QuizType;
using OnlineLearningWebAPI.Models;
using OnlineLearningWebAPI.Repository.IRepository;
using OnlineLearningWebAPI.Service.IService;

namespace OnlineLearningWebAPI.Service
{
    public class QuizTypeService : IQuizTypeService
    {
        private readonly IQuizTypeRepository _quizTypeRepository;

        public QuizTypeService(IQuizTypeRepository quizTypeRepository)
        {
            _quizTypeRepository = quizTypeRepository;
        }

        public async Task<IEnumerable<QuizTypeDTO>> GetAllQuizTypesAsync()
        {
            var quizTypes = await _quizTypeRepository.GetAllAsync();
            return quizTypes.Select(q => new QuizTypeDTO
            {
                QuizTypeId = q.QuizTypeId,
                TypeName = q.TypeName,
            });
        }

        public async Task<QuizTypeDTO?> GetQuizTypeByIdAsync(int id)
        {
            var quizType = await _quizTypeRepository.GetByIdAsync(id);
            if (quizType == null) return null;

            return new QuizTypeDTO
            {
                QuizTypeId = quizType.QuizTypeId,
                TypeName = quizType.TypeName,
            };
        }

        public async Task<bool> CreateQuizTypeAsync(CreateQuizTypeDTO createQuizTypeDTO)
        {
            var quizType = new QuizType
            {
                TypeName = createQuizTypeDTO.TypeName,
            };

            await _quizTypeRepository.AddAsync(quizType);
            await _quizTypeRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateQuizTypeAsync(int id, UpdateQuizTypeDTO updateQuizTypeDTO)
        {
            var quizType = await _quizTypeRepository.GetByIdAsync(id);
            if (quizType == null) return false;

            quizType.TypeName = updateQuizTypeDTO.TypeName ?? quizType.TypeName;

            _quizTypeRepository.Update(quizType);
            await _quizTypeRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteQuizTypeAsync(int id)
        {
            var quizType = await _quizTypeRepository.GetByIdAsync(id);
            if (quizType == null) return false;

            _quizTypeRepository.Delete(quizType);
            await _quizTypeRepository.SaveChangesAsync();
            return true;
        }
    }
}
