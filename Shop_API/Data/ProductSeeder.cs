using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_API.Data
{
    public class ProductSeeder
    {
        private readonly ProductContext _context;
        private readonly IWebHostEnvironment _hosting;

        public ProductSeeder(ProductContext context, IWebHostEnvironment hosting)
        {
            _context = context;
            _hosting = hosting;
        }

        public void Seed()
        {
            _context.Database.EnsureCreated();

            if (!_context.Products.Any())
            {
                // Creates default sample data

            }
        }
    }
}
