using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PXLPro2022Shoppers07.Shared;

namespace Shopper07WebAPI.Data
{
    public class SeedData
    {
        public static async void MigrateAndPopulate(IApplicationBuilder app)
        {
            appDbContext context = app.ApplicationServices.CreateScope().ServiceProvider
                .GetRequiredService<appDbContext>();
            await CreateStock(context);
        }

        static async Task CreateStock(appDbContext context)
        {
            var product = new ProductStock();
            product.ProductName = "Test";
            product.Amount = 3;
            var product2 = new ProductStock();
            product2.ProductName = "Test";
            product2.Amount = 5;
            context.ProductStocks.AddRange(product,product2);
            await context.SaveChangesAsync();
        }


    }
}
