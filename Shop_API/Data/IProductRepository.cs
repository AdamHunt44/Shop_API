using Microsoft.AspNetCore.Mvc;
using Shop_API.Data.Entities;
using Shop_API.Model;
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
        Task<Product[]> GetProductsByCategory(string category);
        Task<Product> GetProductById(int productId);
    }
}