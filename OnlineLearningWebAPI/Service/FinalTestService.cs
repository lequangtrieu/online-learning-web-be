using OnlineLearningWebAPI.DTOs.FinalTestRequest;
using OnlineLearningWebAPI.DTOs.Response.FinalTestResponse;
using OnlineLearningWebAPI.Models;
using OnlineLearningWebAPI.Repository.IRepository;
using OnlineLearningWebAPI.Service.IService;

namespace OnlineLearningWebAPI.Service
{
    public class FinalTestService : IFinalTestService
    {
        private readonly IFinalTestRepository _finalTestRepository;

        public FinalTestService(IFinalTestRepository finalTestRepository)
        {
            _finalTestRepository = finalTestRepository;
        }

        public async Task<IEnumerable<FinalTestDTO>> GetAllFinalTestsAsync()
        {
            var finalTests = await _finalTestRepository.GetAllAsync();
            return finalTests.Select(ft => new FinalTestDTO
            {
                FinalTestId = ft.FinalTestId,
                CourseId = ft.CourseId,
                TestName = ft.TestName,
                Duration = ft.Duration,
                GeneratedFromExamTests = ft.GeneratedFromExamTests
            });
        }

        public async Task<FinalTestDTO?> GetFinalTestByIdAsync(int id)
        {
            var finalTest = await _finalTestRepository.GetByIdAsync(id);
            if (finalTest == null) return null;

            return new FinalTestDTO
            {
                FinalTestId = finalTest.FinalTestId,
                CourseId = finalTest.CourseId,
                TestName = finalTest.TestName,
                Duration = finalTest.Duration,
                GeneratedFromExamTests = finalTest.GeneratedFromExamTests
            };
        }

        public async Task<bool> CreateFinalTestAsync(CreateFinalTestDTO createFinalTestDTO)
        {
            var finalTest = new FinalTest
            {
                CourseId = createFinalTestDTO.CourseId,
                TestName = createFinalTestDTO.TestName,
                Duration = createFinalTestDTO.Duration,
                GeneratedFromExamTests = createFinalTestDTO.GeneratedFromExamTests
            };

            await _finalTestRepository.AddAsync(finalTest);
            await _finalTestRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateFinalTestAsync(int id, UpdateFinalTestDTO updateFinalTestDTO)
        {
            var finalTest = await _finalTestRepository.GetByIdAsync(id);
            if (finalTest == null) return false;

            finalTest.TestName = updateFinalTestDTO.TestName ?? finalTest.TestName;
            finalTest.Duration = updateFinalTestDTO.Duration ?? finalTest.Duration;
            finalTest.GeneratedFromExamTests = updateFinalTestDTO.GeneratedFromExamTests ?? finalTest.GeneratedFromExamTests;

            _finalTestRepository.Update(finalTest);
            await _finalTestRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteFinalTestAsync(int id)
        {
            var finalTest = await _finalTestRepository.GetByIdAsync(id);
            if (finalTest == null) return false;

            _finalTestRepository.Delete(finalTest);
            await _finalTestRepository.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<FinalTestDTO>> GetFinalTestsByCourseIdAsync(int courseId)
        {
            var finalTests = await _finalTestRepository.GetByCourseIdAsync(courseId);
            return finalTests.Select(ft => new FinalTestDTO
            {
                FinalTestId = ft.FinalTestId,
                CourseId = ft.CourseId,
                TestName = ft.TestName,
                Duration = ft.Duration,
                GeneratedFromExamTests = ft.GeneratedFromExamTests
            });
        }
    }
}
