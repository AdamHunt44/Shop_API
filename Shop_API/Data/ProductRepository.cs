using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shop_API.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_API.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;
        private readonly ILogger<ProductRepository> _logger;

        public ProductRepository(ProductContext context, ILogger<ProductRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            // Only returns success if at least one row was changed in the database
            return (await _context.SaveChangesAsync()) > 0;
        }
            
        public async Task<Product[]> GetAllProductsAsync()
        {
            IQueryable<Product> query = _context.Products;

            // Order the Query
            query = query.OrderBy(c => c.ProductId);

            return await query.ToArrayAsync();
        }

        public async Task<Product[]> GetProductsByCategory(string category)
        {
            IQueryable<Product> query = _context.Products;

            // Order the Query
            query = query.Where(c => c.Category == category);

            return await query.ToArrayAsync();
        }

        public async Task<Product> GetProductById(int productId)
        {
            IQueryable<Product> query = _context.Products;

            // Order the Query
            query = query.Where(p => p.ProductId == productId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Product> GetProductAsync(string productName)
        {
            IQueryable<Product> query = _context.Products;

            // Order the Query
            query = query.Where(p => p.Name == productName);

            return await query.FirstOrDefaultAsync();
        }
    }
}
