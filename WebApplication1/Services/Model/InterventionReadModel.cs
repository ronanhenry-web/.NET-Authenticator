namespace WebApplication1.Services.Model
{
    public class InterventionReadModel
    {
        public int Id { get; set; }
        public DateTime ScheduledAt { get; set; }

        public string ClientFullName { get; set; } = default!;
        public List<string> TechnicianFullNames { get; set; } = new();
        public string ServiceTypeName { get; set; } = default!;
    }
}
