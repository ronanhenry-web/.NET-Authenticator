using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Data.Entity;
using WebApplication1.Data.Entity.Identity;
using WebApplication1.DataAccess.Entity;

namespace WebApplication1.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<RefreshTokenEntity> RefreshTokens { get; set; }


        public DbSet<ServiceTypeEntity> ServiceTypes { get; set; }
        public DbSet<InterventionEntity> Interventions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<InterventionEntity>()
            .HasOne(i => i.Client)
            .WithMany()
            .HasForeignKey(i => i.ClientId)
            .OnDelete(DeleteBehavior.Restrict);

                modelBuilder.Entity<InterventionEntity>()
                    .HasMany(i => i.Technicians)
                    .WithMany();
        }
    }
}
