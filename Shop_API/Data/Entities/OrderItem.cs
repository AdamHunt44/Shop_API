using System.ComponentModel.DataAnnotations.Schema;

namespace Shop_API.Data.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public int OrderId { get; set; }
    }
}