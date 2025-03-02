using OnlineLearningWebAPI.DTOs.request.MoocRequest;

namespace OnlineLearningWebAPI.Service.IService;

public interface IMoocService
{
    Task<IEnumerable<MoocDTO>> GetAllMoocsAsync();
    Task<MoocDTO?> GetMoocByIdAsync(int id);
    Task<bool> CreateMoocAsync(CreateMoocDTO createMoocDTO);
    Task<bool> UpdateMoocAsync(int id, UpdateMoocDTO updateMoocDTO);
    Task<bool> DeleteMoocAsync(int id);
    Task<IEnumerable<MoocDTO>> GetMoocsByCourseIdAsync(int courseId);
}
