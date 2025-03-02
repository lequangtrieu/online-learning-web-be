using OnlineLearningWebAPI.DTOs.request.ProfileRequest;
using OnlineLearningWebAPI.DTOs.response;
using OnlineLearningWebAPI.Models;

namespace OnlineLearningWebAPI.Service.IService
{
    public interface IProfileService
    {
        Task<GeneralResponse> AddNewProfile(AddProfileRequest request);
        Task<GeneralResponse> UpdateProfile(UpdateProfileRequest request);
        Profile GetProfileByAccountId(string id);
    }
}
