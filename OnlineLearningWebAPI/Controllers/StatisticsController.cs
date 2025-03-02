using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineLearningWebAPI.Models;
using System.Linq;
using OnlineLearningWebAPI.Data;
using System.Threading.Tasks;

namespace OnlineLearningWebAPI.Controllers
{
    [Route("api/statistic")] // Sửa lại route đúng chuẩn
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private readonly OnlineLearningDbContext _context;

        public StatisticController(OnlineLearningDbContext context)
        {
            _context = context;
        }

        [HttpGet("statistic")]
        public async Task<IActionResult> GetStatistics()
        {
            // Lấy 5 khóa học có lượt mua cao nhất
            var topCourses = await _context.OrderDetails
                .GroupBy(o => new { o.CourseId, o.Course.CourseTitle })
                .Select(g => new
                {
                    CourseTitle = g.Key.CourseTitle,
                    TotalSales = g.Sum(o => o.Quantity)
                })
                .OrderByDescending(c => c.TotalSales)
                .Take(5)
                .ToListAsync();

            // Tổng doanh thu
            decimal totalRevenue = await _context.OrderDetails.SumAsync(o => o.Price * o.Quantity);

            // Phần trăm doanh thu theo khóa học
            var revenueDistribution = await _context.OrderDetails
                .GroupBy(o => new { o.CourseId, o.Course.CourseTitle })
                .Select(g => new
                {
                    CourseTitle = g.Key.CourseTitle,
                    RevenuePercentage = totalRevenue > 0 ? (g.Sum(o => o.Price * o.Quantity) / totalRevenue) * 100 : 0
                })
                .OrderByDescending(r => r.RevenuePercentage)
                .ToListAsync();

            return Ok(new
            {
                topCourses,
                totalRevenue,
                revenueDistribution
            });
        }
    }
}
