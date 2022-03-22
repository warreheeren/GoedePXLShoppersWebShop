﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PXLPro2022Shoppers07.Models;
using PXLPro2022Shoppers07.ViewModels;

namespace PXLPro2022Shoppers07.Data
{
    public class appDbContext : IdentityDbContext<UserDetails>
    {
        public appDbContext(DbContextOptions<appDbContext> options) : base (options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<FavoriteProduct> Favorites { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
