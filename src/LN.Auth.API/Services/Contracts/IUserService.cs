using LN.Auth.API.Models;

namespace LN.Auth.API.Services.Contracts
{
    public interface IUserService
    {
        Task<Response> RegisterUserAsync(RegisterModel model);
        Task<UserDTO?> GetUserProfileAsync(string userId);
    }
}
