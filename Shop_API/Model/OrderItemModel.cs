using Shop_API.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_API.Model
{
    public class OrderItemModel
    {
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        public int ProductId { get; set; }

        public string ProductCategory { get; set; }
        public string ProductName { get; set; }

        public int OrderID { get; set; }
        public Order Order { get; set; }
    }
}
