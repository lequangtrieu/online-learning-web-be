using Microsoft.EntityFrameworkCore;
using OnlineLearningWebAPI.Data;
using OnlineLearningWebAPI.Models;
using OnlineLearningWebAPI.Repository.IRepository;

namespace OnlineLearningWebAPI.Repository;

public class MoocRepository : IMoocRepository
{
    private readonly OnlineLearningDbContext _context;

    public MoocRepository(OnlineLearningDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Mooc>> GetAllAsync()
    {
        return await _context.Moocs.ToListAsync();
    }

    public async Task<Mooc?> GetByIdAsync(int id)
    {
        return await _context.Moocs.FindAsync(id);
    }

    public async Task AddAsync(Mooc mooc)
    {
        await _context.Moocs.AddAsync(mooc);
    }

    public void Update(Mooc mooc)
    {
        _context.Moocs.Update(mooc);
    }

    public void Delete(Mooc mooc)
    {
        _context.Moocs.Remove(mooc);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Mooc>> GetMoocsByCourseIdAsync(int courseId)
    {
        return await _context.Moocs
            .Where(m => m.CourseId == courseId)
            .ToListAsync();
    }
}
