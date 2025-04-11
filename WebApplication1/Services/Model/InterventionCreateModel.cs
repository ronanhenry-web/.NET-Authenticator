using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Services.Model
{
    public class InterventionCreateModel
    {
        [Required(ErrorMessage = "REQUIRED_DATE")]
        public DateTime ScheduledAt { get; set; }
        [Required(ErrorMessage = "REQUIRED_CLIENT")]
        public string ClientId { get; set; } = default!;
        [Required(ErrorMessage = "REQUIRED_TECHNICIANS")]
        [MinLength(1, ErrorMessage = "MIN_ONE_TECHNICIAN")]
        public List<string> TechnicianIds { get; set; } = new();
        [Required(ErrorMessage = "REQUIRED_SERVICE_TYPE")]
        public int ServiceTypeId { get; set; }
    }

}
