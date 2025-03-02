using OnlineLearningWebAPI.DTOs.request.TeacherRequest;
using OnlineLearningWebAPI.DTOs.Response.TeacherResponse;

namespace OnlineLearningWebAPI.Service
{
    public interface IStudentService
    {
        Task<bool> BanStudentAsync(string id);
        Task<List<AccountDTO>> GetAllStudentsAsync();
        Task<bool> UnbanStudentAsync(string id);
        Task<AccountDTO?> GetStudentByIdAsync(string id);
        Task<bool> UpdateStudentDetailsAsync(string id, UpdateAccountDTO updateStudentDTO);
    }
}