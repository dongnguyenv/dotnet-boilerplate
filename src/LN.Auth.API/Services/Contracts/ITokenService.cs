using LN.Auth.API.Models;
using Microsoft.AspNetCore.Identity;

namespace LN.Auth.API.Services.Contracts
{
    public interface ITokenService
    {
        Task<TokenResult?> LoginAsync(LoginModel model);
        Task<IdentityUser?> ValidateToken(string token);
    }
}
