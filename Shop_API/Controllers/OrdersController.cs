using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shop_API.Data;
using Shop_API.Data.Entities;
using Shop_API.Model;
using System;
using System.Threading.Tasks;

namespace Shop_API.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
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


        [HttpPost]
        public async Task<ActionResult<OrderModel>> CreateNewOrder(Order orderModel)
        {
            try
            {
                var existing = await _repository.GetOrderById(orderModel.Id);
                if (existing != null)
                {
                    return BadRequest("Product with the same name already exists");
                }

                // Creating a new Order
                var newOrder = _mapper.Map<Order>(orderModel);
                _repository.Add(newOrder);
                if (await _repository.SaveChangesAsync())
                {
                    return Created($"/api/products/{orderModel.OrderNumber}", _mapper.Map<OrderModel>(newOrder));
                }
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Fatal Error: {ex}");
            }
            return BadRequest();
        }

        [HttpPut("{orderNumber}")]
        public async Task<ActionResult<ProductModel>> UpdateOrderByOrderNumber(string orderNumber, OrderModel orderModel)
        {
            try
            {
                var selectedProduct = await _repository.GetOrderByOrderNumber(orderNumber);
                if (selectedProduct == null) return NotFound($"Could not find a Order with the corresponding number: {orderNumber}");

                _mapper.Map(orderModel, selectedProduct);

                if (await _repository.SaveChangesAsync())
                {
                    return _mapper.Map<ProductModel>(selectedProduct);
                }

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Fatal Error: {ex}");
            }

            return BadRequest();
        }
    }
}
