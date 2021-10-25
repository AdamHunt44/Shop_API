using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shop_API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_API.Controllers
{
    [Route("/api/order/{orderid}/items")]
    public class OrderItemsController
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public readonly ILogger<OrderItemsController> _logger;

        public OrderItemsController(IProductRepository repository, ILogger<OrderItemsController> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
    }
}
