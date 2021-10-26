﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_API.Model
{
    public class ProductModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
    }
}
