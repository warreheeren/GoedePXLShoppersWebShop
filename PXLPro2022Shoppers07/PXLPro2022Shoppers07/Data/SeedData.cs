using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using PXLPro2022Shoppers07.Models;

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



            UserManager<UserDetails> userManager = app.ApplicationServices.CreateScope().ServiceProvider
                .GetRequiredService<UserManager<UserDetails>>();
            await CreateRolesAsync(context, roleManager);
            await CreateIdentityRecordAsync(context, userManager, roleManager, "admin@pxl.be", "Adm!n007", Roles.Admin);

            await CreateIdentityRecordAsync(context, userManager, roleManager, "Client@pxl.be", "Cl3nt001!", Roles.Client);

            await CreateIdentityRecordAsync(context, userManager, roleManager, "Client@pxl.be", "Cl3nt001!", Roles.Admin);

            await CreateProduct(context);
        }

        static async Task CreateProduct(appDbContext context)
        {
            var category = new Category();
            category.CategoryName = "Test";
            category.Description = "Lorem ipsum";
            var image = new ProductImage();
            var image2 = new ProductImage();
            image.Name = "Test";
            image.ProductImageByte = await File.ReadAllBytesAsync(@"Images/Porsche.jpg");
            image2.Name = "Test2";
            image2.ProductImageByte = await File.ReadAllBytesAsync(@"Images/Ferrari.jpg");
            var product = new Product();
            product.ProductName = "Test";
            product.Price = 3000;
            product.Category = category;
            product.ProductImage = new List<ProductImage> { image,image2};

            context.Products.Add(product);
            await context.SaveChangesAsync();
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


        private static async Task CreateIdentityRecordAsync(appDbContext context, UserManager<UserDetails> userManager, RoleManager<IdentityRole> roleManager, string email,string pwd, string role)
        {

            if (await userManager.FindByEmailAsync(email) == null)
            {
                await CreateRolesAsync(context, roleManager);

                var identityUser = new UserDetails() { Email = email, UserName = email };
                var result = await userManager.CreateAsync(identityUser, pwd);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(identityUser, role);
                }
            }
        }

    }
}
