using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Services.Model
{
    public class LoginModel
    {

        [Required(ErrorMessage = "REQUIRED_EMAIL")]
        [EmailAddress(ErrorMessage = "INVALID_EMAIL")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "REQUIRED_PASSWORD")]
        public string Password { get; set; } = string.Empty;
    }
}
