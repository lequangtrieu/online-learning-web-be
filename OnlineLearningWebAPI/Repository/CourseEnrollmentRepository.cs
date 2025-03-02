using Microsoft.EntityFrameworkCore;
using OnlineLearningWebAPI.Data;
using OnlineLearningWebAPI.Models;
using OnlineLearningWebAPI.Repository.IRepository;

namespace OnlineLearningWebAPI.Repository;

public class CourseEnrollmentRepository : ICourseEnrollmentRepository
{
    private readonly OnlineLearningDbContext _context;

    public CourseEnrollmentRepository(OnlineLearningDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CourseEnrollment>> GetAllAsync()
    {
        return await _context.CourseEnrollments.ToListAsync();
    }

    public async Task<CourseEnrollment?> GetByIdAsync(int id)
    {
        return await _context.CourseEnrollments.FindAsync(id);
    }

    public async Task AddAsync(CourseEnrollment courseEnrollment)
    {
        await _context.CourseEnrollments.AddAsync(courseEnrollment);
    }

    public void Update(CourseEnrollment courseEnrollment)
    {
        _context.CourseEnrollments.Update(courseEnrollment);
    }

    public void Delete(CourseEnrollment courseEnrollment)
    {
        _context.CourseEnrollments.Remove(courseEnrollment);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<CourseEnrollment>> GetEnrollmentsByCourseIdAsync(int courseId)
    {
        return await _context.CourseEnrollments
            .Where(e => e.CourseId == courseId)
            .ToListAsync();
    }

    public async Task<IEnumerable<CourseEnrollment>> GetEnrollmentsByAccountIdAsync(string accountId)
    {
        return await _context.CourseEnrollments
            .Where(e => e.AccountId == accountId)
            .ToListAsync();
    }
}
