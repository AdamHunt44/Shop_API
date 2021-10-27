using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shop_API.Data.Entities;
using System;

namespace Shop_API.Data
{
    public class ShopContext : DbContext
    {
        private readonly IConfiguration _config;

        public ShopContext(DbContextOptions<ShopContext> options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("SHOPAPI"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Explicit database types.
            modelBuilder.Entity<OrderItem>()
                .Property(m => m.UnitPrice)
                .HasPrecision(10, 3);

            modelBuilder.Entity<Product>()
                .Property(m => m.Price)
                .HasPrecision(10, 3);

            // Seed data.
            modelBuilder.Entity<Product>()
                .HasData(new Product
                {
                    ProductId = 1,
                    Name = "Coffee mug",
                    Price = 3.99m,
                    Description = "Tall blue coffee mug",
                    Quantity = 10,
                    Category = "Kitchen"
                });

            modelBuilder.Entity<Product>()
                .HasData(new Product
                {
                    ProductId = 2,
                    Name = "Step Ladder",
                    Price = 27.99m,
                    Description = "A heavy duty aluminium step ladder",
                    Quantity = 10,
                    Category = "Tools"
                });

            modelBuilder.Entity<Product>()
                .HasData(new Product
                {
                    ProductId = 3,
                    Name = "Kettle",
                    Price = 13.99m,
                    Description = "A proper brew",
                    Quantity = 10,
                    Category = "Kitchen"
                });

            modelBuilder.Entity<Order>()
                .HasData(new Order
                {
                    Id = 1,
                    OrderDate = DateTime.Today,
                    OrderNumber = "1234"
                });

            modelBuilder.Entity<OrderItem>()
                .HasData(new OrderItem
                {
                    Id = 1,
                    OrderId = 1,
                    ProductId = 1,
                    Quantity = 5,
                    UnitPrice = 3.99m
                });

            modelBuilder.Entity<OrderItem>()
                .HasData(new OrderItem
                {
                    Id = 2,
                    OrderId = 1,
                    ProductId = 3,
                    Quantity = 5,
                    UnitPrice = 13.99m
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}