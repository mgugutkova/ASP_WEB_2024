using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using PawnShop.Infrastructure.Data.Model;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions 
    {
        public static async Task CreateAdminRoleAsync(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (userManager != null && roleManager != null && await roleManager.RoleExistsAsync("AdminRole") == false)
            {
                var role = new IdentityRole("AdminRole");

                await roleManager.CreateAsync(role);

                var admin = await userManager.FindByEmailAsync("admin@abv.bg");

                if (admin != null)
                {
                    await userManager.AddToRoleAsync(admin, role.Name);
                }
            }
        }

        public static async Task CreateUserRoleAsync(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (userManager != null && roleManager != null && await roleManager.RoleExistsAsync("UserRole") == false)
            {
                var role = new IdentityRole("UserRole");

                await roleManager.CreateAsync(role);

                var msef = await userManager.FindByEmailAsync("msef@abv.bg");

                if (msef != null)
                {
                    await userManager.AddToRoleAsync(msef, role.Name);
                }

                var ksef = await userManager.FindByEmailAsync("ksef@abv.bg");

                if (ksef != null)
                {
                    await userManager.AddToRoleAsync(ksef, role.Name);
                }
            }
        }
    }
}
