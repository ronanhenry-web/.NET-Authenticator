using WebApplication1.Data;
using WebApplication1.DataAccess.Entity;

namespace WebApplication1.DataAccess.Seed
{
    public static class ServiceTypeSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.ServiceTypes.Any())
            {
                context.ServiceTypes.AddRange(
                    new ServiceTypeEntity { Name = "Chauffage" },
                    new ServiceTypeEntity { Name = "Électricité" },
                    new ServiceTypeEntity { Name = "Réseau" }
                );

                context.SaveChanges();
            }
        }
    }
}
