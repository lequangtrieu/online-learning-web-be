using OnlineLearningWebAPI.DTOs.request.MoocRequest;
using OnlineLearningWebAPI.Models;
using OnlineLearningWebAPI.Repository.IRepository;
using OnlineLearningWebAPI.Service.IService;

namespace OnlineLearningWebAPI.Service;

public class MoocService : IMoocService
{
    private readonly IMoocRepository _moocRepository;

    public MoocService(IMoocRepository moocRepository)
    {
        _moocRepository = moocRepository;
    }

    public async Task<IEnumerable<MoocDTO>> GetAllMoocsAsync()
    {
        var moocs = await _moocRepository.GetAllAsync();
        return moocs.Select(m => new MoocDTO
        {
            MoocId = m.MoocId,
            CourseId = m.CourseId,
            Description = m.Description,
            CreateDate = m.CreateDate,
            IsPublic = m.IsPublic,
        });
    }

    public async Task<MoocDTO?> GetMoocByIdAsync(int id)
    {
        var mooc = await _moocRepository.GetByIdAsync(id);
        if (mooc == null) return null;

        return new MoocDTO
        {
            MoocId = mooc.MoocId,
            CourseId = mooc.CourseId,
            Description = mooc.Description,
            CreateDate = mooc.CreateDate,
            IsPublic = mooc.IsPublic,
        };
    }

    public async Task<bool> CreateMoocAsync(CreateMoocDTO createMoocDTO)
    {
        var mooc = new Mooc
        {
            CourseId = createMoocDTO.CourseId,
            Description = createMoocDTO.Description,
            CreateDate = createMoocDTO.CreateDate,
            IsPublic = createMoocDTO.IsPublic,
        };

        await _moocRepository.AddAsync(mooc);
        await _moocRepository.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateMoocAsync(int id, UpdateMoocDTO updateMoocDTO)
    {
        var mooc = await _moocRepository.GetByIdAsync(id);
        if (mooc == null) return false;

        mooc.Description = updateMoocDTO.Description ?? mooc.Description;
        mooc.IsPublic = updateMoocDTO.IsPublic ?? mooc.IsPublic;

        _moocRepository.Update(mooc);
        await _moocRepository.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteMoocAsync(int id)
    {
        var mooc = await _moocRepository.GetByIdAsync(id);
        if (mooc == null) return false;

        _moocRepository.Delete(mooc);
        await _moocRepository.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<MoocDTO>> GetMoocsByCourseIdAsync(int courseId)
    {
        var moocs = await _moocRepository.GetMoocsByCourseIdAsync(courseId);
        return moocs.Select(m => new MoocDTO
        {
            MoocId = m.MoocId,
            CourseId = m.CourseId,
            Description = m.Description,
            CreateDate = m.CreateDate,
            IsPublic = m.IsPublic,
        });
    }
}
