using Microsoft.EntityFrameworkCore;
using Shopper07WebAPI.Models;

namespace Shopper07WebAPI.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<Stock> Stock { get; set; } 
    }
}
