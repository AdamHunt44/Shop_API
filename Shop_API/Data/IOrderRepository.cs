using Shop_API.Data.Entities;
using System.Threading.Tasks;

namespace Shop_API.Data
{
    public interface IOrderRepository
    {
        // General 
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        // Orders
        Task<Order[]> GetAllOrders(bool includeItems);
        Task<Order> GetOrderById(bool includeItems);


        // Order Items
        Task<OrderItem[]> GetAllOrderItemsAsync();
    }
}