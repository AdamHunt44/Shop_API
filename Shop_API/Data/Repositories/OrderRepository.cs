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

        public async Task<Order[]> GetAllOrders(bool includeItems)
        {
            IQueryable<Order> query = _context.Orders;

            // Order the Query
            query = query.OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }

        public async Task<OrderItem[]> GetAllOrderItemsAsync()
        {
            IQueryable<OrderItem> query = _context.Items;

            // Order the Query
            query = query.OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Order> GetOrderById(int orderId)
        {
            IQueryable<Order> query = _context.Orders;

            query = query.Where(o => o.Id == orderId);
            query = query.Include(o => o.Items);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Order> GetOrderByOrderNumber(string orderNumber)
        {
            IQueryable<Order> query = _context.Orders;

            query = query.Where(o => o.OrderNumber == orderNumber);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<OrderItem> GetOrderItemById(int orderItemId)
        {
            IQueryable<OrderItem> query = _context.Items;

            // Order the Query
            query = query.OrderBy(c => c.Id)
                .Where(i => i.Id == orderItemId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<OrderItem[]> GetAllItemsByOrderId(int orderId)
        {
            IQueryable<OrderItem> query = _context.Items;

            // Order the Query
            query = query.OrderBy(c => c.Id)
                .Where(i => i.Id == orderId);

            return await query.ToArrayAsync();
        }
    }
}
