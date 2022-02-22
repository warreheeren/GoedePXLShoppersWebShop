using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace PXLPro2022Shoppers07.Data
{
    public class Roles
    {
        public const string Admin = "Admin";
        public const string Client = "Client";

    }

    public class SeedData
    {

        public static async void MigrateAndPopulate(IApplicationBuilder app)
        {
            appDbContext context = app.ApplicationServices.CreateScope().ServiceProvider
                .GetRequiredService<appDbContext>();

            RoleManager<IdentityRole> roleManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();



            UserManager<IdentityUser> userManager = app.ApplicationServices.CreateScope().ServiceProvider
                .GetRequiredService<UserManager<IdentityUser>>();
            await CreateRolesAsync(context, roleManager);
            await CreateIdentityRecordAsync(context, userManager, roleManager, "admin@pxl.be", "Adm!n007", Roles.Admin);
            await CreateIdentityRecordAsync(context, userManager, roleManager, "Client@pxl.be", "Cl3nt001!", Roles.Client);
        }

        public static async Task CreateRolesAsync(appDbContext context, RoleManager<IdentityRole> roleManager)
        {
            if (!context.Roles.Any())
            {
                await CreateRoleAsync(roleManager, Roles.Admin);
                await CreateRoleAsync(roleManager, Roles.Client);
            }

        }

        public static async Task CreateRoleAsync(RoleManager<IdentityRole> roleManager, string roleName)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                IdentityRole role = new IdentityRole(roleName);
                await roleManager.CreateAsync(role);
            }
        }

        private static async Task CreateIdentityRecordAsync(appDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, string email,string pwd, string role)
        {

            if (await userManager.FindByEmailAsync(email) == null)
            {
                await CreateRolesAsync(context, roleManager);
                var identityUser = new IdentityUser() { Email = email, UserName = email};
                var result = await userManager.CreateAsync(identityUser, pwd);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(identityUser, role);
                }
            }
        }

    }
}
