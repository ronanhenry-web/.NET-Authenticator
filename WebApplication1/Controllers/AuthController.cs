using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services.Auth;
using WebApplication1.Services.Model;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var result = await _authService.RegisterAsync(model);
            return result is null ? BadRequest("Register failed") : Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var result = await _authService.LoginAsync(model);
            return result is null ? Unauthorized("Invalid credentials") : Ok(result);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh(RefreshRequestModel model)
        {
            var result = await _authService.RefreshTokenAsync(model);
            return result is null ? Unauthorized("Invalid refresh token") : Ok(result);
        }
    }
}
