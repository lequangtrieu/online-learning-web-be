using Microsoft.AspNetCore.Identity;
using OnlineLearningWebAPI.DTOs.request.TeacherRequest;
using OnlineLearningWebAPI.DTOs.Response.TeacherResponse;
using OnlineLearningWebAPI.Models;

namespace OnlineLearningWebAPI.Service
{
    public class StudentService : IStudentService
    {
        private readonly string STUDENT_ROLE = "Student";

        private readonly UserManager<Account> _userManager;
        private readonly ILogger<StudentService> _logger;

        public StudentService(UserManager<Account> userManager, ILogger<StudentService> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<List<AccountDTO>> GetAllStudentsAsync()
        {
            var accounts = _userManager.Users.ToList();
            var studentAccounts = new List<AccountDTO>();

            foreach (var account in accounts)
            {
                var roles = await _userManager.GetRolesAsync(account);
                if (roles.Contains(STUDENT_ROLE))
                {
                    studentAccounts.Add(new AccountDTO
                    {
                        Id = account.Id,
                        Email = account.Email,
                        UserName = account.UserName,
                        IsBan = account.IsBan,
                        Avatar = account.Avatar,
                        IsVip = account.IsVip,
                        Role = STUDENT_ROLE
                    });
                }
            }

            return studentAccounts;
        }

        public async Task<bool> BanStudentAsync(string id)
        {
            var student = await _userManager.FindByIdAsync(id);
            if (student == null)
            {
                _logger.LogError($"[StudentService] | BanStudentAsync | Studentnot found with ID: {id}");
                return false;
            }

            if (student.IsBan.HasValue && student.IsBan.Value)
            {
                _logger.LogError($"[StudentService] | BanStudentAsync | Studentwith ID: {id} was already baned");
                return false;
            }

            var roles = await _userManager.GetRolesAsync(student);
            if (!roles.Contains(STUDENT_ROLE))
            {
                _logger.LogError($"[StudentService] | BanStudentAsync | Studentwith ID: {id} does not have the required role: {STUDENT_ROLE}");
                return false;
            }

            student.IsBan = true;
            await _userManager.UpdateAsync(student);
            return true;
        }
        public async Task<bool> UnbanStudentAsync(string id)
        {
            var student = await _userManager.FindByIdAsync(id);
            if (student == null)
            {
                _logger.LogError($"[StudentService] | BanStudentAsync | Studentnot found with ID: {id}");
                return false;
            }

            if (!(student.IsBan.HasValue && student.IsBan.Value))
            {
                _logger.LogError($"[StudentService] | UnbanStudentAsync | Studentwith ID: {id} was not baned");
                return false;
            }

            var roles = await _userManager.GetRolesAsync(student);
            if (!roles.Contains(STUDENT_ROLE))
            {
                _logger.LogError($"[StudentService] | BanStudentAsync | Studentwith ID: {id} does not have the required role: {STUDENT_ROLE}");
                return false;
            }

            student.IsBan = false;
            await _userManager.UpdateAsync(student);
            return true;
        }

        public async Task<AccountDTO?> GetStudentByIdAsync(string id)
        {
            var student = await _userManager.FindByIdAsync(id);
            if (student == null)
            {
                _logger.LogError($"[StudentService] | GetStudentByIdAsync | Studentnot found with ID: {id}");
                return null;
            }

            var roles = await _userManager.GetRolesAsync(student);
            if (!roles.Contains(STUDENT_ROLE))
            {
                _logger.LogError($"[StudentService] | GetStudentByIdAsync | Studentwith ID: {id} does not have the required role: {STUDENT_ROLE}");
                return null;
            }

            return new AccountDTO
            {
                Id = student.Id,
                UserName = student.UserName,
                Email = student.Email,
                Avatar = student.Avatar,
                IsVip = student.IsVip,
                Role = STUDENT_ROLE
            };
        }

        public async Task<bool> UpdateStudentDetailsAsync(string id, UpdateAccountDTO updateStudentDTO)
        {
            var student = await _userManager.FindByIdAsync(id);
            if (student == null)
            {
                _logger.LogError($"[StudentService] | UpdateStudentDetailsAsync | Studentnot found with ID: {id}");
                return false;
            }

            var roles = await _userManager.GetRolesAsync(student);
            if (!roles.Contains(STUDENT_ROLE))
            {
                _logger.LogError($"[StudentService] | UpdateStudentDetailsAsync | Studentwith ID: {id} does not have the required role: {STUDENT_ROLE}");
                return false;
            }

            student.UserName = updateStudentDTO.UserName ?? student.UserName;
            student.Avatar = updateStudentDTO.Avatar ?? student.Avatar;
            student.IsVip = updateStudentDTO.IsVip ?? student.IsVip;
            student.Email = updateStudentDTO.Email ?? student.Email;

            var result = await _userManager.UpdateAsync(student);
            if (!result.Succeeded)
            {
                _logger.LogError($"[StudentService] | UpdateStudentDetailsAsync | Failed to update Studentwith ID: {id}. " +
                    $"Errors: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                return false;
            }
            return true;
        }
    }
}
