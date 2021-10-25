﻿using System.ComponentModel.DataAnnotations;

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

        public string ProductSize { get; set; }

        public string ProductName { get; set; }
    }
}