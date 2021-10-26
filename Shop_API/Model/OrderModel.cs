using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_API.Model
{
    public class OrderModel
    {
        [Required]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        [Required]
        public string OrderNumber { get; set; }
        public ICollection<OrderItemModel> Items { get; set; }
    }
}
