using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shop_API.Data.Entities;

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("SHOPAPI"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>()
                .Property(m => m.UnitPrice)
                .HasPrecision(10, 3);

            modelBuilder.Entity<Product>()
                .HasData(new Product
                {
                    ProductId = 1,
                    Name = "Coffee mug",
                    Price = 3.99,
                    Description = "Tall blue coffee mug",
                    Quantity = 1
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}