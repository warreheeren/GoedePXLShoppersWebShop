﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PXLPro2022Shoppers07.Models;

namespace PXLPro2022Shoppers07.Data
{
    public class appDbContext : IdentityDbContext<IdentityUser>
    {
        public appDbContext(DbContextOptions<appDbContext> options) : base (options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
