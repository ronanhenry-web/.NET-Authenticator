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

        [HttpPost("register/client")]
        public async Task<IActionResult> RegisterClient([FromBody] RegisterModel model)
        {
            var result = await _authService.RegisterAsync(model, "client");
            return Ok(result);
        }

        [HttpPost("register/technicien")]
        public async Task<IActionResult> RegisterTechnicien([FromBody] RegisterModel model)
        {
            var result = await _authService.RegisterAsync(model, "technicien");
            return Ok(result);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var response = await _authService.LoginAsync(model);
            return response is null ? Unauthorized("Invalid credentials") : Ok(response);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshRequestModel model)
        {
            var response = await _authService.RefreshTokenAsync(model);
            return response is null ? Unauthorized("Invalid refresh token") : Ok(response);
        }
    }
}
