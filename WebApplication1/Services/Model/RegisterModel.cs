using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Services.Model
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "REQUIRED_EMAIL")]
        [EmailAddress(ErrorMessage = "INVALID_EMAIL")]
        public string Email { get; set; } = default!;
        [Required(ErrorMessage = "REQUIRED_PASSWORD")]
        [MinLength(6, ErrorMessage = "Le mot de passe doit contenir au moins 6 caractères")]
        public string Password { get; set; } = default!;
        [Required(ErrorMessage = "REQUIRED_DISPLAYNAME")]
        public string DisplayName { get; set; } = default!;
    }
}
