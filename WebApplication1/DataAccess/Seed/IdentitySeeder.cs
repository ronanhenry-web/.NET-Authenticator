using Microsoft.AspNetCore.Identity;
using WebApplication1.Data.Entity.Identity;

namespace WebApplication1.DataAccess.Seed
{
    public class IdentitySeeder
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            if (!await roleManager.RoleExistsAsync("admin"))
            {
                await roleManager.CreateAsync(new ApplicationRole { Name = "admin" });
            }

            var email = "admin@example.com";
            var password = "Admin123!";
            var user = await userManager.FindByEmailAsync(email);

            if (user == null)
            {
                user = new ApplicationUser
                {
                    Email = email,
                    UserName = email,
                    DisplayName = "Admin"
                };
                var result = await userManager.CreateAsync(user, password);
                if (!result.Succeeded) return;
            }

            if (!await userManager.IsInRoleAsync(user, "admin"))
            {
                await userManager.AddToRoleAsync(user, "admin");
            }
        }
    }
}
