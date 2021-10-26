using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shop_API.Data.Entities;
using System;
using Shop_API.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_API.Data
{
    public class ProductContext : DbContext
    {
        private readonly IConfiguration _config;

        public ProductContext(DbContextOptions<ProductContext> options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("SHOPAPI"));
        }

        protected override void OnModelCreating(ModelBuilder bldr)
        {
            bldr.Entity<Product>()
                .HasData(new
                {
                    ProductId = 5,
                    Name = "TEST2",
                    Price = 3.50,
                    Description = "A new test product for our users",
                    Quantity = 50,
                    Category = "TEST"
                });

            bldr.Entity<OrderItem>()
                .Property(p => p.UnitPrice)
                .HasColumnType("decimal(18,4)");

            /*            bldr.Entity<Order>()
                            .HasData(new Order
                            {
                                Id = 1,
                                OrderDate = DateTime.UtcNow,
                                OrderNumber = "12345"
                            });*/
        }
    }
}
