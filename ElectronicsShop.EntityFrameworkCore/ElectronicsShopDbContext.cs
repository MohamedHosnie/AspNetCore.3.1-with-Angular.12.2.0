﻿using ElectronicsShop.Domain.Orders;
using ElectronicsShop.Domain.Products;
using ElectronicsShop.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace ElectronicsShop.EntityFrameworkCore
{
    public class ElectronicsShopDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }

        private static DbContextOptions<ElectronicsShopDbContext> _options;
        public ElectronicsShopDbContext() 
            : base(_options)
        {
        }
        public ElectronicsShopDbContext(DbContextOptions<ElectronicsShopDbContext> options) 
            : base(options)
        {
            _options = options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Product)
                .WithMany(p => p.Orders)
                .HasForeignKey(o => o.ProductId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Seed();
        }
    }
}
