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
        Task<Order[]> GetAllOrders();
        Task<Order> GetOrderById(int orderId);
        Task<Order> GetOrderByOrderNumber(string orderNumber);

        // Order Items
        Task<OrderItem[]> GetAllOrderItemsAsync();
        Task<OrderItem> GetOrderItemById(int orderItemId);
        Task<OrderItem[]> GetAllItemsByOrderId(int orderId);
    }
}