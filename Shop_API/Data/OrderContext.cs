/*using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shop_API.Data.Entities;
using System;

namespace Shop_API.Data
{
    public class OrderContext : DbContext
    {
        private readonly IConfiguration _config;

        public OrderContext(DbContextOptions<OrderContext> options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        public DbSet<Order> Orders{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("SHOPAPI"));
        }

        protected override void OnModelCreating(ModelBuilder bldr)
        {
            bldr.Entity<OrderItem>()
                .Property(o => o.UnitPrice)
                .HasColumnType("money");

            bldr.Entity<Order>()
                .HasData(new Order
                {
                    Id = 1,
                    OrderDate = DateTime.UtcNow,
                    OrderNumber = "12345"
                });
        }
    }
}
*/