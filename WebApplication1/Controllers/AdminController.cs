using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("admin")]
    [Authorize]
    public class AdminController : ControllerBase
    {
        [HttpGet("crash")]
        [Authorize(Roles = "admin")]
        public IActionResult Crash()
        {
            throw new InvalidOperationException("Bouuuuuummmmm");
        }

        [HttpGet("me")]
        [Authorize]
        public IActionResult Me()
        {
            var identity = User.Identity;
            var roles = User.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);
            return Ok(new
            {
                identity?.Name,
                identity?.IsAuthenticated,
                roles = roles.ToList()
            });
        }

    }

}
