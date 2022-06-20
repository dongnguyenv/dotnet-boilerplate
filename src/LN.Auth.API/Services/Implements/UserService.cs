using AutoMapper;
using LN.Auth.API.Models;
using LN.Auth.API.Services.Contracts;
using Microsoft.AspNetCore.Identity;

namespace LN.Auth.API.Services.Implements
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        public readonly IMapper _mapper;

        public UserService(UserManager<IdentityUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<UserDTO?> GetUserProfileAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<Response> RegisterUserAsync(RegisterModel model)
        {
            var userExist = await _userManager.FindByNameAsync(model.Username);
            if (userExist != null)
            {
                return new Response
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Succeeded = false,
                    Data = new {
                        Status = "Error",
                        Message = "Username already existed"
                    }
                };
            }

            IdentityUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded) {
                return new Response
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Succeeded = false,
                    Data = new {
                        Status = "Error",
                        Message = "User creation failed! Please check user details and try again."
                    }
                };
            }

            return new Response
            {
                StatusCode = StatusCodes.Status201Created,
                Succeeded = true,
                Data = new
                {
                    Status = "Success",
                    Message = "User created successfully!"
                }
            };
        }
    }
}
