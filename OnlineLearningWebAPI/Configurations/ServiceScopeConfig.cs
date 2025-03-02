using OnlineLearningWebAPI.Models;
using OnlineLearningWebAPI.Repository;
using OnlineLearningWebAPI.Repository.IRepository;
using OnlineLearningWebAPI.Service;
using OnlineLearningWebAPI.Service.IService;

namespace OnlineLearningWebAPI.Configurations
{
    public static class ServiceScopeConfig
    {
        public static IServiceCollection AddServiceScopeConfig(this IServiceCollection services)
        {
            // Add Repository Scope
            //builder.Services.AddScoped<IRepository<Account>, AccountRepository>();

            services.AddScoped<IRepository<Profile>, Repository.Repository<Profile>>();
            services.AddScoped<IRepository<Account>, Repository.Repository<Account>>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ICourseCategoryRepository, CourseCategoryRepository>();
            services.AddScoped<ICourseTagRepository, CourseTagRepository>();
            services.AddScoped<ICourseEnrollmentRepository, CourseEnrollmentRepository>();
            services.AddScoped<IMoocRepository, MoocRepository>();

            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<IProfileService, ProfileService>();

            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ICourseCategoryService, CourseCategoryService>();
            services.AddScoped<ICourseTagService, CourseTagService>();
            services.AddScoped<ICourseEnrollmentService, CourseEnrollmentService>();
            services.AddScoped<IMoocService, MoocService>();

            services.AddScoped<IQuizAnswerRepository, QuizAnswerRepository>();
            services.AddScoped<IQuizAnswerService, QuizAnswerService>();

            services.AddScoped<IQuizRepository, QuizRepository>();
            services.AddScoped<IQuizService, QuizService>();

            services.AddScoped<IExamTestRepository, ExamTestRepository>();
            services.AddScoped<IExamTestService, ExamTestService>();

            services.AddScoped<IFinalTestRepository, FinalTestRepository>();
            services.AddScoped<IFinalTestService, FinalTestService>();

            services.AddScoped<IFinalTestQuizRepository, FinalTestQuizRepository>();
            services.AddScoped<IFinalTestQuizService, FinalTestQuizService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddScoped<IOpenAIService, OpenAIService>();
            services.AddScoped<IScheduleService, ScheduleService>();

            services.AddScoped<IScheduleRepository, ScheduleRepository>();
            return services;
        }
    }
}
