using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shop_API.Data;
using Shop_API.Model;
using System;
using System.Threading.Tasks;

namespace Shop_API.Controllers
{
    [Route("api/[controller]/")]
    public class OrdersController : Controller
    {
        private readonly IOrderRepository _repository;
        private readonly ILogger<OrderItemsController> _logger;
        private readonly IMapper _mapper;

        public OrdersController(IOrderRepository repository,
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
                var results = await _repository.GetAllOrders(includeItems);

                OrderModel[] allOrders = _mapper.Map<OrderModel[]>(results);

                return Ok(allOrders);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpGet("{orderId:int}")]
        public async Task<ActionResult<OrderModel>> GetOrderById(int orderId)
        {
            try
            {
                var result = await _repository.GetOrderById(orderId);
                if (result == null) return NotFound();

                return _mapper.Map<OrderModel>(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Database Fatal Error: {ex}");
            }
        }
    }


}
