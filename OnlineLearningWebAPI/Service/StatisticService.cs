using OnlineLearningWebAPI.Data;
using OnlineLearningWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

public class StatisticService
{
    private readonly OnlineLearningDbContext _context;

    public StatisticService(OnlineLearningDbContext context)
    {
        _context = context;
    }

    // Lấy 5 khóa học có lượt mua cao nhất
    public IEnumerable<object> GetTopCourses()
    {
        var topCourses = _context.OrderDetails
            .GroupBy(o => o.Course.CourseTitle)
            .Select(g => new
            {
                CourseTitle = g.Key,
                TotalSales = g.Sum(o => o.Quantity) // Tổng số lượt mua
            })
            .OrderByDescending(c => c.TotalSales)
            .Take(5)
            .ToList();

        return topCourses;
    }

    // Lấy tổng doanh thu và phần trăm doanh thu theo từng khóa học
    public object GetRevenueData()
    {
        var totalRevenue = _context.OrderDetails.Sum(o => o.Price * o.Quantity); // Tổng doanh thu

        var revenueData = _context.OrderDetails
            .GroupBy(o => o.Course.CourseTitle)
            .Select(g => new
            {
                CourseTitle = g.Key,
                Revenue = g.Sum(o => o.Price * o.Quantity), // Tổng doanh thu từng khóa
                Percentage = (totalRevenue > 0) ? (g.Sum(o => o.Price * o.Quantity) / totalRevenue) * 100 : 0 // Phần trăm
            })
            .ToList();

        return new
        {
            TotalRevenue = totalRevenue,
            RevenueBreakdown = revenueData
        };
    }
}
