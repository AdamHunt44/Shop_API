using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shop_API.Data;
using Shop_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                var results = _repository.GetAllOrders(includeItems);

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
