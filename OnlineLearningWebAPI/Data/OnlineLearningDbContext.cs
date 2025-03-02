using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineLearningWebAPI.Enum;
using OnlineLearningWebAPI.Models;

namespace OnlineLearningWebAPI.Data;

public partial class OnlineLearningDbContext : IdentityDbContext<Account>
{
    public OnlineLearningDbContext()
    {
    }

    public OnlineLearningDbContext(DbContextOptions<OnlineLearningDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ActivityLog> ActivityLogs { get; set; }

    public virtual DbSet<Certificate> Certificates { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseCategory> CourseCategories { get; set; }

    public virtual DbSet<CourseEnrollment> CourseEnrollments { get; set; }

    public virtual DbSet<CourseTag> CourseTags { get; set; }

    public virtual DbSet<ExamTest> ExamTests { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<FinalTest> FinalTests { get; set; }

    public virtual DbSet<FinalTestQuiz> FinalTestQuizzes { get; set; }

    public virtual DbSet<Mooc> Moocs { get; set; }

    public virtual DbSet<Quiz> Quizzes { get; set; }

    public virtual DbSet<QuizAnswer> QuizAnswers { get; set; }

    public virtual DbSet<QuizType> QuizTypes { get; set; }

    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<OrderDetail> OrderDetails { get; set; }
    public virtual DbSet<Schedule> Schedules { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        optionsBuilder.EnableSensitiveDataLogging(false);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Cấu hình các thực thể chung
        ConfigureCommonEntities(modelBuilder);

        // Cấu hình các thực thể riêng biệt
        ConfigureActivityLogEntity(modelBuilder);
        ConfigureCertificateEntity(modelBuilder);
        ConfigureCourseEntity(modelBuilder);
        ConfigureCourseCategoryEntity(modelBuilder);
        ConfigureCourseEnrollmentEntity(modelBuilder);
        ConfigureCourseTagEntity(modelBuilder);
        ConfigureExamTestEntity(modelBuilder);
        ConfigureFeedbackEntity(modelBuilder);
        ConfigureFinalTestEntity(modelBuilder);
        ConfigureMoocEntity(modelBuilder);
        ConfigureQuizEntity(modelBuilder);
        ConfigureQuizAnswerEntity(modelBuilder);
        ConfigureQuizTypeEntity(modelBuilder);
        ConfigureSeekData(modelBuilder);
        ConfigureOrderEntity(modelBuilder);
        ConfigureOrderDetailEntity(modelBuilder);
    }

    private void ConfigureSeekData(ModelBuilder modelBuilder)
    {
        // Seed data cho các Role
        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole { Id = "2", Name = "Student", NormalizedName = "STUDENT" },
            new IdentityRole { Id = "3", Name = "VIP Student", NormalizedName = "VIP STUDENT" },
            new IdentityRole { Id = "4", Name = "Teacher", NormalizedName = "TEACHER" }
        );

        // Seed data cho Account
        modelBuilder.Entity<Account>().HasData(
            new Account
            {
                Id = "1",
                UserName = "admin_user",
                Email = "admin@example.com",
                Avatar = "admin.png",
                IsBan = false,
                IsVip = false,
                PasswordHash = "Aa1234@"
            },
            new Account
            {
                Id = "2",
                UserName = "student_user",
                Email = "student@example.com",
                Avatar = "student.png",
                IsBan = false,
                IsVip = false,
                PasswordHash = "Aa1234@"
            }
        );

        // Seed data cho AspNetUserRoles
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string> { UserId = "1", RoleId = "1" }, // Admin
            new IdentityUserRole<string> { UserId = "2", RoleId = "2" } // Student
        );

        modelBuilder.Entity<CourseCategory>().HasData(
            new CourseCategory
            {
                CategoryId = 1,
                Name = "Artificial Intelligence"
            },
            new CourseCategory
            {
                CategoryId = 2,
                Name = "Programming Languages"
            }
        );

        modelBuilder.Entity<Course>().HasData(
            new Course
            {
                CourseId = 1,
                CourseTitle = "Introduction to AI",
                TeacherId = "2",
                Description = "Learn the fundamentals of Artificial Intelligence.",
                CreateDate = DateOnly.FromDateTime(DateTime.UtcNow),
                CategoryId = 1,
                Status = CourseStatus.Pending
            },
            new Course
            {
                CourseId = 2,
                CourseTitle = "Advanced Python Programming",
                TeacherId = "2",
                Description = "Master Python with advanced concepts and libraries.",
                CreateDate = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(-30)),
                CategoryId = 2,
                Status = CourseStatus.Approved
            }
        );

        modelBuilder.Entity<CourseEnrollment>().HasData(
            new CourseEnrollment
            {
                CourseEnrollmentId = 1,
                CourseId = 1,
                AccountId = "2"
            },
            new CourseEnrollment
            {
                CourseEnrollmentId = 2,
                CourseId = 2,
                AccountId = "2"
            }
        );

        modelBuilder.Entity<CourseTag>().HasData(
            new CourseTag
            {
                CourseTagId = 1,
                CourseId = 1,
                TagName = "AI"
            },
            new CourseTag
            {
                CourseTagId = 2,
                CourseId = 2,
                TagName = "Python"
            }
        );

        modelBuilder.Entity<Feedback>().HasData(
            new Feedback
            {
                FeedbackId = 1,
                AccountId = "2",
                CourseId = 1,
                FeedbackText = "Great course on AI!"
            },
            new Feedback
            {
                FeedbackId = 2,
                AccountId = "2",
                CourseId = 2,
                FeedbackText = "The Python content is very insightful!"
            }
        );

        // Seed data for OrderDetail
        modelBuilder.Entity<OrderDetail>().HasData(
            new OrderDetail
            {
                OrderDetailId = 1,
                OrderId = 1,
                CourseId = 1,
                Price = 50.00m,
                Quantity = 2
            },
            new OrderDetail
            {
                OrderDetailId = 2,
                OrderId = 2,
                CourseId = 2,
                Price = 200.00m,
                Quantity = 1
            }
        );

        // Seed data for Order
        modelBuilder.Entity<Order>().HasData(
            new Order
            {
                OrderId = 1,
                UserId = "1",
                OrderDate = new DateTime(2025, 1, 1),
                TotalAmount = 100.00m,
                PaymentMethod = "Credit Card",
                Description = "First order by user1",
                Status = OrderStatus.Completed // Sử dụng Enum
            },
            new Order
            {
                OrderId = 2,
                UserId = "2",
                OrderDate = new DateTime(2025, 1, 2),
                TotalAmount = 200.00m,
                PaymentMethod = "PayPal",
                Description = "Second order by user2",
                Status = OrderStatus.Pending // Sử dụng Enum
            }
        );

    }

    private void ConfigureCommonEntities(ModelBuilder modelBuilder)
    {
        // Các thực thể chung, ví dụ như cấu hình DateTime
        modelBuilder.Entity<AuditEntity>(entity =>
        {
            // Đảm bảo rằng AuditEntity không có khóa chính
            entity.HasNoKey();

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("GETDATE()");
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("GETDATE()");
        });
    }

    private void ConfigureActivityLogEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActivityLog>(entity =>
        {
            entity.HasKey(e => e.ActivityLogId);
            entity.ToTable("ActivityLog");

            entity.Property(e => e.ActivityLogId).HasColumnName("activityLogId");
            entity.Property(e => e.AccountId).HasColumnName("accountId");

            // Cấu hình quan hệ với Account
            entity.HasOne(d => d.Account)
                  .WithMany(p => p.ActivityLogs)
                  .HasForeignKey(d => d.AccountId)
                  .OnDelete(DeleteBehavior.ClientSetNull);
        });
    }

    private void ConfigureCertificateEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Certificate>(entity =>
        {
            entity.HasKey(e => e.CertificateId);
            entity.ToTable("Certificate");

            entity.Property(e => e.CertificateId).HasColumnName("certificateId");
            entity.Property(e => e.AccountId).HasColumnName("accountId");

            // Cấu hình quan hệ với Account
            entity.HasOne(d => d.Account)
                  .WithMany(p => p.Certificates)
                  .HasForeignKey(d => d.AccountId)
                  .OnDelete(DeleteBehavior.ClientSetNull);
        });
    }

    private void ConfigureCourseEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId);
            entity.ToTable("Course");

            entity.Property(e => e.CourseId).HasColumnName("courseId");
            entity.Property(e => e.CategoryId).HasColumnName("categoryId");

            // Cấu hình quan hệ với Category và Teacher
            entity.HasOne(d => d.Category)
                  .WithMany(p => p.Courses)
                  .HasForeignKey(d => d.CategoryId)
                  .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Teacher)
                  .WithMany(p => p.Courses)
                  .HasForeignKey(d => d.TeacherId)
                  .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Course>()
            .Property(o => o.Status)
            .HasConversion<int>(); // Ánh xạ enum thành int trong database
    }

    private void ConfigureCourseCategoryEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CourseCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId);
            entity.ToTable("CourseCategory");
            entity.Property(e => e.CategoryId).HasColumnName("categoryId");
            entity.Property(e => e.Name).HasMaxLength(255).HasColumnName("name");
        });
    }

    private void ConfigureCourseEnrollmentEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CourseEnrollment>(entity =>
        {
            entity.HasKey(e => e.CourseEnrollmentId);
            entity.ToTable("CourseEnrollment");

            entity.Property(e => e.CourseEnrollmentId).HasColumnName("courseEnrollmentId");
            entity.Property(e => e.AccountId).HasColumnName("accountId");

            // Cấu hình quan hệ với Account và Course
            entity.HasOne(d => d.Account)
                  .WithMany(p => p.CourseEnrollments)
                  .HasForeignKey(d => d.AccountId)
                  .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Course)
                  .WithMany(p => p.CourseEnrollments)
                  .HasForeignKey(d => d.CourseId)
                  .OnDelete(DeleteBehavior.ClientSetNull);
        });
    }

    private void ConfigureCourseTagEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CourseTag>(entity =>
        {
            entity.HasKey(e => e.CourseTagId).HasName("PK__CourseTa__E7E342A0200F6BB1");

            entity.Property(e => e.CourseTagId).HasColumnName("courseTagId");
            entity.Property(e => e.CourseId).HasColumnName("courseId");
            entity.Property(e => e.TagName)
                .HasMaxLength(255)
                .HasColumnName("tagName");

            entity.HasOne(d => d.Course).WithMany(p => p.CourseTags)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CourseTag__cours__5BE2A6F2");
        });
    }

    private void ConfigureExamTestEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExamTest>(entity =>
        {
            entity.HasKey(e => e.ExamTestId).HasName("PK__ExamTest__DC7B3C15142788E6");

            entity.ToTable("ExamTest");

            entity.Property(e => e.ExamTestId).HasColumnName("examTestId");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.MoocId).HasColumnName("moocId");
            entity.Property(e => e.TestName)
                .HasMaxLength(255)
                .HasColumnName("testName");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ExamTests)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ExamTest__create__52593CB8");

            entity.HasOne(d => d.Mooc).WithMany(p => p.ExamTests)
                .HasForeignKey(d => d.MoocId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ExamTest__moocId__5165187F");
        });
    }

    private void ConfigureFeedbackEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId);
            entity.ToTable("Feedback");

            entity.Property(e => e.FeedbackId).HasColumnName("feedbackId");
            entity.Property(e => e.AccountId).HasColumnName("accountId");

            // Cấu hình quan hệ với Account
            entity.HasOne(d => d.Account)
                  .WithMany(p => p.Feedbacks)
                  .HasForeignKey(d => d.AccountId)
                  .OnDelete(DeleteBehavior.ClientSetNull);
        });
    }

    private void ConfigureFinalTestEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FinalTest>(entity =>
        {
            entity.HasKey(e => e.FinalTestId);
            entity.ToTable("FinalTest");

            entity.Property(e => e.FinalTestId).HasColumnName("finalTestId");
            entity.Property(e => e.CourseId).HasColumnName("courseId");

            // Cấu hình quan hệ với Course
            entity.HasOne(d => d.Course)
                  .WithMany(p => p.FinalTests)
                  .HasForeignKey(d => d.CourseId)
                  .OnDelete(DeleteBehavior.ClientSetNull);
        });
    }

    private void ConfigureMoocEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Mooc>(entity =>
        {
            entity.HasKey(e => e.MoocId).HasName("PK__MOOC__48B763A16B548D41");

            entity.ToTable("MOOC");

            entity.Property(e => e.MoocId).HasColumnName("moocId");
            entity.Property(e => e.CourseId).HasColumnName("courseId");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("createDate");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IsPublic)
                .HasDefaultValue(false)
                .HasColumnName("isPublic");

            entity.HasOne(d => d.Course).WithMany(p => p.Moocs)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MOOC__courseId__5070F446");
        });

    }

    private void ConfigureQuizEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Quiz>(entity =>
        {
            entity.HasKey(e => e.QuizId).HasName("PK__Quiz__CFF54C3D65A7B54F");

            entity.ToTable("Quiz");

            entity.Property(e => e.QuizId).HasColumnName("quizId");
            entity.Property(e => e.ExamTestId).HasColumnName("examTestId");
            entity.Property(e => e.MaxScore).HasColumnName("maxScore");
            entity.Property(e => e.QuizName)
                .HasMaxLength(255)
                .HasColumnName("quizName");
            entity.Property(e => e.QuizQuestion).HasColumnName("quizQuestion");
            entity.Property(e => e.QuizTypeId).HasColumnName("quizTypeId");

            entity.HasOne(d => d.ExamTest).WithMany(p => p.Quizzes)
                .HasForeignKey(d => d.ExamTestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Quiz__examTestId__534D60F1");

            entity.HasOne(d => d.QuizType).WithMany(p => p.Quizzes)
                .HasForeignKey(d => d.QuizTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Quiz__quizTypeId__5441852A");
        });
    }

    private void ConfigureQuizAnswerEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<QuizAnswer>(entity =>
        {
            entity.HasKey(e => e.QuizAnswerId);
            entity.ToTable("QuizAnswer");

            entity.Property(e => e.QuizAnswerId).HasColumnName("quizAnswerId");
            entity.Property(e => e.QuizId).HasColumnName("quizId");

            // Cấu hình quan hệ với Quiz
            entity.HasOne(d => d.Quiz)
                  .WithMany(p => p.QuizAnswers)
                  .HasForeignKey(d => d.QuizId)
                  .OnDelete(DeleteBehavior.ClientSetNull);
        });
    }

    private void ConfigureQuizTypeEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<QuizType>(entity =>
        {
            entity.HasKey(e => e.QuizTypeId);
            entity.ToTable("QuizType");

            entity.Property(e => e.QuizTypeId).HasColumnName("quizTypeId");
            entity.Property(e => e.TypeName).HasMaxLength(255).HasColumnName("typeName");
        });
    }

    private void ConfigureProfileEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Profile>(entity =>
        {
            entity.HasKey(e => e.ProfileId);
            entity.Property(e => e.ProfileId).ValueGeneratedOnAdd();
            entity.ToTable("Profile");

            entity.HasOne(d => d.Account)
                  .WithOne(p => p.Profile)
                  .HasForeignKey<Profile>(d => d.AccountId)
                  .OnDelete(DeleteBehavior.ClientSetNull);
        });
    }

    private void ConfigureOrderEntity(ModelBuilder modelBuilder)
    {
        // Quan hệ giữa Order và Account
        modelBuilder.Entity<Order>()
            .HasOne(o => o.User)
            .WithMany(a => a.Orders)
            .HasForeignKey(o => o.UserId)
            .HasPrincipalKey(a => a.Id);

        // Cấu hình cơ bản cho Order
        modelBuilder.Entity<Order>()
            .Property(o => o.TotalAmount)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Order>()
            .Property(o => o.Status)
            .HasConversion<int>(); // Ánh xạ enum thành int trong database

        modelBuilder.Entity<Order>()
            .Property(o => o.Description)
            .HasMaxLength(500)
            .IsUnicode(true);
    }

    private void ConfigureOrderDetailEntity(ModelBuilder modelBuilder)
    {
        // Quan hệ giữa OrderDetail và Order
        modelBuilder.Entity<OrderDetail>()
            .HasOne(od => od.Order)
            .WithMany(o => o.OrderDetails)
            .HasForeignKey(od => od.OrderId);

        // Quan hệ giữa OrderDetail và Course
        modelBuilder.Entity<OrderDetail>()
            .HasOne(od => od.Course)
            .WithMany(c => c.OrderDetails)
            .HasForeignKey(od => od.CourseId);

        // Cấu hình cơ bản cho OrderDetail
        modelBuilder.Entity<OrderDetail>()
            .Property(od => od.Price)
            .HasColumnType("decimal(18,2)");
    }


    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
