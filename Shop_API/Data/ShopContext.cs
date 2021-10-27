using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shop_API.Data.Entities;
using System.Collections.Generic;

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
            modelBuilder.Entity<OrderItem>()
                .Property(m => m.UnitPrice)
                .HasPrecision(10, 3);

            var productA = new Product
            {
                ProductId = 1,
                Name = "Coffee mug",
                Price = 3.99m,
                Description = "Tall blue coffee mug",
                Quantity = 10,
                Category = "Kitchen"
            };

            var productC = new Product
            {
            ProductId = 3,
                Name = "Kettle",
                Price = 13.99m,
                Description = "A proper brew",
                Quantity = 10,
                Category = "Kitchen"
            };


            modelBuilder.Entity<Product>()
                .HasData(productA);

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
                .HasData(productC);

            modelBuilder.Entity<Order>(o => o.HasData (new Order
                {
                    Id = 1,
                    OrderDate = System.DateTime.Today,
                    OrderNumber = "1234",
                    Items = new List<OrderItem>()
                    {
                        new OrderItem()
                        {
                            Id = 1,
                            Product = productA,
                            Quantity = 5,
                            UnitPrice = productA.Price,
                        },
                        
                        new OrderItem()
                        {
                            Id = 2,
                            Product = productC,
                            Quantity = 5,
                            UnitPrice = productC.Price,
                        }
                    }
                }));

            base.OnModelCreating(modelBuilder);
        }
    }
}