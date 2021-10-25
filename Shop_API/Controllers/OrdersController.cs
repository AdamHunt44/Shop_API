using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shop_API.Data.Repositories;
using Shop_API.Model;
using System;
using System.Threading.Tasks;

namespace Shop_API.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : Controller
    {
        private readonly IOrderRepository _repository;
        private readonly ILogger<OrderItemsController> _logger;
        private readonly IMapper _mapper;

        public OrdersController(
            IOrderRepository repository,
            ILogger<OrderItemsController> logger,
            IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<OrderModel[]>> GetAllOrders(bool includeItems = true)
        {
            try
            {
                var results = await _repository.GetAllOrdersAsync(includeItems);

                OrderModel[] allOrders = _mapper.Map<OrderModel[]>(results);

                return Ok(allOrders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}