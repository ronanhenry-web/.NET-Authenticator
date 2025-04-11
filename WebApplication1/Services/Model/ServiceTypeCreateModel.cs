using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Services.Model
{
    public class ServiceTypeCreateModel
    {
        [Required(ErrorMessage = "REQUIRED_NAME")]
        [MinLength(3, ErrorMessage = "NAME_TOO_SHORT")]
        public string Name { get; set; } = default!;
    }

}
