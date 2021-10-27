using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shop_API.Data.Repositories;

namespace Shop_API.Controllers
{
    [Route("/api/orders/{orderid}/items")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<OrderItemsController> _logger;
        private readonly IMapper _mapper;

        public OrderItemsController(IProductRepository repository, ILogger<OrderItemsController> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
    }
}