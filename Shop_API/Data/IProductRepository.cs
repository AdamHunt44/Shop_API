using Shop_API.Data.Entities;
using System;
using System.Threading.Tasks;

namespace Shop_API.Data
{
    public interface IProductRepository
    {
        // General 
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        // Products
        Task<Product[]> GetAllProductsAsync();
        Task<Product> GetProductAsync(string productName);
        Task<Product[]> GetAllProductsByPrice();
        Task<Product> GetProductById(int productId);
    }
}