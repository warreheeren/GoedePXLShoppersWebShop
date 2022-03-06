using System.Collections.Generic;
using System.IO;
using System.Linq;
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

            var img1 = await File.ReadAllBytesAsync(@"Images/img1.jpg");
            var img2 = await File.ReadAllBytesAsync(@"Images/img2.jpg");
            var img3 = await File.ReadAllBytesAsync(@"Images/img3.jpg");
            var img4 = await File.ReadAllBytesAsync(@"Images/img4.jpg");
            Dictionary<string,byte[]> list = new Dictionary<string, byte[]>();
            list.Add("Img1", img1);
            list.Add("Img2", img2);
            list.Add("Img3", img3);
            list.Add("Img4", img4);

            await CreateProdocutDy(context, "Ultra Wireless Headphones", 3000, "Headphones","",  list);
        }


        static async Task CreateProdocutDy(appDbContext context, string productName, decimal price,string categoryName, string description, Dictionary<string,byte[]> images)
        {
            var checkproduct = context.Products.FirstOrDefault(x => x.ProductName == productName);
            if (checkproduct == null)
            {
                var checkCategory = context.Categories.FirstOrDefault(x => x.CategoryName == categoryName);
                var productImages = new List<ProductImage>();
                foreach (var image in images)
                {
                    productImages.Add(new ProductImage { Name = image.Key, ProductImageByte = image.Value });
                }
                var product = new Product
                {
                    ProductName = productName,
                    Price = price,
                    ProductImage = productImages,
                };
                if (checkCategory == null)
                {
                    var category = new Category
                    {
                        CategoryName = categoryName,
                        Description = description,
                    };

                    product.Category = category;
                }
                else
                {
                    product.Category = checkCategory;
                }
                context.Products.Add(product);
                await context.SaveChangesAsync();
            }
        }


        public static async Task CreateRolesAsync(appDbContext context, RoleManager<IdentityRole> roleManager)
        {
            if (!EnumerableExtensions.Any(context.Roles))
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
