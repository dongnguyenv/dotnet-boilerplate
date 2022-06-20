using LN.Auth.API.Services.Contracts;

namespace LN.Auth.API.Helpers
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        public JwtMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context, ITokenService tokenService)
        {
            // Authorization: Bearer <token>
            var token = context.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();
            // get current logged in user and attach to context
            if (token is not null) {
                try
                {
                    var user = await tokenService.ValidateToken(token);
                    context.Items["User"] = user;
                }
                catch {
                    // do notiong
                }
            }

            await _next(context);
        }
    }
}
