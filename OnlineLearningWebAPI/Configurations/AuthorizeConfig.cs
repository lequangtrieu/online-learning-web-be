namespace OnlineLearningWebAPI.Configurations
{
    public static class AuthorizeConfig
    {
        public static IServiceCollection AddAuthorizeConfig(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdminRole", policy =>
                    policy.RequireRole("Admin"));

                options.AddPolicy("RequireStudentRole", policy =>
                    policy.RequireRole("Student"));

                options.AddPolicy("RequireVIPStudentRole", policy =>
                    policy.RequireRole("VIP Student"));

                options.AddPolicy("RequireTeacherRole", policy =>
                    policy.RequireRole("Teacher"));

                // external authorize
                options.AddPolicy("MustBeAdult", policy =>
                    policy.RequireAssertion(context =>
                        context.User.HasClaim(c => c.Type == "Age" && int.Parse(c.Value) >= 18)
                    ));
            });

            return services;
        }
    }
}
