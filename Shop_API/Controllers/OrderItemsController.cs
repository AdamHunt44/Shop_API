using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shop_API.Data;
using Shop_API.Model;
using System;
using System.Threading.Tasks;

namespace Shop_API.Controllers
{
    [Route("/api/orders/{orderid}/items")]
    [Route("/api/items/{itemId}")]
    [Route("/api/items")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderRepository _repository;
        private readonly ILogger<OrderItemsController> _logger;
        private readonly IMapper _mapper;

        public OrderItemsController(IOrderRepository repository, ILogger<OrderItemsController> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<OrderItemModel[]>> GetAllOrderItems()
        {
            try
            {
                var results = await _repository.GetAllOrderItemsAsync();

                OrderItemModel[] allOrderItems = _mapper.Map<OrderItemModel[]>(results);

                return Ok(allOrderItems);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpGet("{orderItemId:int}")]
        public async Task<ActionResult<OrderItemModel>> GetOrderItemById(int orderItemId)
        {
            try
            {
                var results = await _repository.GetOrderItemById(orderItemId);

                OrderItemModel orderItem = _mapper.Map<OrderItemModel>(results);

                return Ok(orderItem);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}