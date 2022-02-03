using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VendingMachine.Services.DTO;
using VendingMachine.Services.Interfaces.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VendingMachine.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            // _logger = logger;
            _orderService = orderService;
        }

        // GET: api/Order
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<OrderDto>))]
        public async Task<IActionResult> Get()
        {
            var items = await _orderService.GetOrdersAsync();
            return Ok(items);
        }

        // GET api/Order/5
        [HttpGet("{OrderId:int}", Name = "GetByOrderId")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ProductDto>> GetById(int id)
        {
            if (id <= 0)
                return BadRequest(id);

            var data = await _orderService.GetByIdAsync(id);

            if (data == null)
                return NotFound();

            return Ok(data);
        }

        // POST api/Order
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateOrderDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<OrderDto>> Post([FromBody] CreateOrderDto orderDto)
        {
            if (orderDto == null)
                return BadRequest();

            var data = await _orderService.AddOrderAsync(orderDto);

            if (data == null)
                return NotFound();

            return Ok(data);
        }

        // PUT api/Order/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
