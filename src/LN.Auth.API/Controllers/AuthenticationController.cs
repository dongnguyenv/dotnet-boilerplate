using LN.Auth.API.Models;
using LN.Auth.API.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LN.Auth.API.Controllers
{
    [Authorize]
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;

        public AuthenticationController(ITokenService tokenService, IUserService userService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginModel model)
        {
            var token = await _tokenService.LoginAsync(model);
            if (token is null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterModel model)
        {
            var result = await _userService.RegisterUserAsync(model);
            if (!result.Succeeded) {
                return StatusCode(result.StatusCode, result);
            }
            return Ok(result);
        }

        // Change Password
        // Forgot Password
        // Reset Password
    }
}
