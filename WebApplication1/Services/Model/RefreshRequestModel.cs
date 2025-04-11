using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Services.Model
{
    public class RefreshRequestModel
    {
        [Required(ErrorMessage = "REQUIRED_REFRESH")]
        public string RefreshToken { get; set; } = string.Empty;
    }
}
