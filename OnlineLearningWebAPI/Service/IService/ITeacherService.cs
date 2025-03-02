using OnlineLearningWebAPI.DTOs;
using OnlineLearningWebAPI.DTOs.request.TeacherRequest;
using OnlineLearningWebAPI.DTOs.Response.TeacherResponse;

namespace OnlineLearningWebAPI.Service.IService
{
    public interface ITeacherService  
    {
        Task<AccountDTO?> GetTeacherByIdAsync(string id);
        Task<List<AccountDTO>> GetAllTeachersAsync();
        Task<bool> UpdateTeacherDetailsAsync(string id, UpdateAccountDTO updateTeacherDTO);
        Task<bool> BanTeacherAsync(string id);
        Task<bool> UnbanTeacherAsync(string id);
    }
}
