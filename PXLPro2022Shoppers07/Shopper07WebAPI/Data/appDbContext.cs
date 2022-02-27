using Microsoft.EntityFrameworkCore;
using PXLPro2022Shoppers07.Shared;

namespace Shopper07WebAPI.Data
{
    public class appDbContext : DbContext
    {
        public appDbContext(DbContextOptions<appDbContext> options) : base(options)
        {
            
        }

        public DbSet<ProductStock> ProductStocks { get; set; }

    }
}
