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

            string[] roles = { "admin", "client", "technicien" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new ApplicationRole { Name = role });
                }
            }

            var usersToCreate = new List<(string email, string displayName, string role)>
            {
                ("admin@example.com", "Admin", "admin"),
                ("client@example.com", "Client", "client"),
                ("tech@example.com", "Technicien", "technicien")
            };

            foreach (var (email, displayName, role) in usersToCreate)
            {
                var user = await userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    user = new ApplicationUser
                    {
                        Email = email,
                        UserName = email,
                        DisplayName = displayName
                    };

                    var result = await userManager.CreateAsync(user, "Test123!");
                    if (!result.Succeeded) continue;
                }

                if (!await userManager.IsInRoleAsync(user, role))
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
        }
    }
}
