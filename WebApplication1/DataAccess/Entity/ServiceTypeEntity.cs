namespace WebApplication1.DataAccess.Entity
{
    public class ServiceTypeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;

        public ICollection<InterventionEntity> Interventions { get; set; } = new List<InterventionEntity>();
    }
}
