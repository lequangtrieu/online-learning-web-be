using OnlineLearningWebAPI.DTOs.request.CourseEnrollmentRequest;
using OnlineLearningWebAPI.DTOs.Response.CourseEnrollmentResponse;
using OnlineLearningWebAPI.Models;
using OnlineLearningWebAPI.Repository.IRepository;
using OnlineLearningWebAPI.Service.IService;

namespace OnlineLearningWebAPI.Service
{
    public class CourseEnrollmentService : ICourseEnrollmentService
    {
        private readonly ICourseEnrollmentRepository _enrollmentRepository;

        public CourseEnrollmentService(ICourseEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        public async Task<IEnumerable<CourseEnrollmentDTO>> GetAllEnrollmentsAsync()
        {
            var enrollments = await _enrollmentRepository.GetAllAsync();
            return enrollments.Select(e => new CourseEnrollmentDTO
            {
                CourseEnrollmentId = e.CourseEnrollmentId,
                AccountId = e.AccountId,
                CourseId = e.CourseId,
                EnrollmentDate = e.EnrollmentDate,
                ProgressPercentage = e.ProgressPercentage,
                IsCompleted = e.IsCompleted,
            });
        }

        public async Task<CourseEnrollmentDTO?> GetEnrollmentByIdAsync(int id)
        {
            var enrollment = await _enrollmentRepository.GetByIdAsync(id);
            if (enrollment == null) return null;

            return new CourseEnrollmentDTO
            {
                CourseEnrollmentId = enrollment.CourseEnrollmentId,
                AccountId = enrollment.AccountId,
                CourseId = enrollment.CourseId,
                EnrollmentDate = enrollment.EnrollmentDate,
                ProgressPercentage = enrollment.ProgressPercentage,
                IsCompleted = enrollment.IsCompleted,
            };
        }

        public async Task<bool> EnrollAsync(CreateCourseEnrollmentDTO createEnrollmentDTO)
        {
            var enrollment = new CourseEnrollment
            {
                AccountId = createEnrollmentDTO.AccountId,
                CourseId = createEnrollmentDTO.CourseId,
                EnrollmentDate = createEnrollmentDTO.EnrollmentDate,
                ProgressPercentage = createEnrollmentDTO.ProgressPercentage,
                IsCompleted = createEnrollmentDTO.IsCompleted,
            };

            await _enrollmentRepository.AddAsync(enrollment);
            await _enrollmentRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateEnrollmentProgressAsync(int id, UpdateCourseEnrollmentDTO updateEnrollmentDTO)
        {
            var enrollment = await _enrollmentRepository.GetByIdAsync(id);
            if (enrollment == null) return false;

            enrollment.ProgressPercentage = updateEnrollmentDTO.ProgressPercentage ?? enrollment.ProgressPercentage;
            enrollment.IsCompleted = updateEnrollmentDTO.IsCompleted ?? enrollment.IsCompleted;

            _enrollmentRepository.Update(enrollment);
            await _enrollmentRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteEnrollmentAsync(int id)
        {
            var enrollment = await _enrollmentRepository.GetByIdAsync(id);
            if (enrollment == null) return false;

            _enrollmentRepository.Delete(enrollment);
            await _enrollmentRepository.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CourseEnrollmentDTO>> GetEnrollmentsByCourseIdAsync(int courseId)
        {
            var enrollments = await _enrollmentRepository.GetEnrollmentsByCourseIdAsync(courseId);
            return enrollments.Select(e => new CourseEnrollmentDTO
            {
                CourseEnrollmentId = e.CourseEnrollmentId,
                AccountId = e.AccountId,
                CourseId = e.CourseId,
                EnrollmentDate = e.EnrollmentDate,
                ProgressPercentage = e.ProgressPercentage,
                IsCompleted = e.IsCompleted,
            });
        }

        public async Task<IEnumerable<CourseEnrollmentDTO>> GetEnrollmentsByAccountIdAsync(string accountId)
        {
            var enrollments = await _enrollmentRepository.GetEnrollmentsByAccountIdAsync(accountId);
            return enrollments.Select(e => new CourseEnrollmentDTO
            {
                CourseEnrollmentId = e.CourseEnrollmentId,
                AccountId = e.AccountId,
                CourseId = e.CourseId,
                EnrollmentDate = e.EnrollmentDate,
                ProgressPercentage = e.ProgressPercentage,
                IsCompleted = e.IsCompleted,
            });
        }
    }
}
