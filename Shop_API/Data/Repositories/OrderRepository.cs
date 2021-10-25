using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shop_API.Data.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_API.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ShopContext _context;
        private readonly ILogger<OrderRepository> _logger;

        public OrderRepository(ShopContext context, ILogger<OrderRepository> logger)
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

        public async Task<Order[]> GetAllOrdersAsync(bool includeItems)
        {
            IQueryable<Order> query = _context.Orders;

            // Order the Query
            if (includeItems)
            {
                query = query
                    .Include(c => c.Items);
            }
            query = query.OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }

        public Task<OrderItem[]> GetAllOrderItemsAsync()
        {
            throw new NotImplementedException();
        }
    }
}