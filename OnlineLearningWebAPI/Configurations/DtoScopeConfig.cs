using Microsoft.EntityFrameworkCore;
using Net.payOS;
using OnlineLearningWebAPI.Data;
using OnlineLearningWebAPI.DTOs.request.EmailRequest;

namespace OnlineLearningWebAPI.Configurations
{
    public static class DtoScopeConfig
    {
        public static IServiceCollection AddDtoScopeConfig(this IServiceCollection services, WebApplicationBuilder builder, IConfiguration configuration)
        {
            services.AddDbContext<OnlineLearningDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")).EnableSensitiveDataLogging(false));

            services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));

            services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

            PayOS payOS = new PayOS(configuration["PayOsSettings:PAYOS_CLIENT_ID"] ?? throw new Exception("Cannot find environment"),
                configuration["PayOsSettings:PAYOS_API_KEY"] ?? throw new Exception("Cannot find environment"),
                configuration["PayOsSettings:PAYOS_CHECKSUM_KEY"] ?? throw new Exception("Cannot find environment"));

            services.AddSingleton(payOS);

            return services;
        }
    }
}
