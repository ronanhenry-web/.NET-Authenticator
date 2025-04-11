using WebApplication1.Data.Entity.Identity;

namespace WebApplication1.DataAccess.Entity
{
    public class InterventionEntity
    {
        public int Id { get; set; }
        public DateTime ScheduledAt { get; set; }

        public string ClientId { get; set; } = default!;
        public ApplicationUser Client { get; set; } = default!;
        public ICollection<ApplicationUser> Technicians { get; set; } = new List<ApplicationUser>();


        public int ServiceTypeId { get; set; }
        public ServiceTypeEntity ServiceType { get; set; } = default!;
    }
}
