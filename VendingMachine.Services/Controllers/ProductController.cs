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
    public class ProductController : ControllerBase
    {
        //private readonly ILogger<Product> _logger;
        IProductService _productService;
        public ProductController(IProductService productService)
        {
            // _logger = logger;
            _productService = productService;
        }

        // GET: api/Product
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ProductDto>))]
        public async Task<IActionResult> Get()
        {
            var products = await _productService.GetProductsAsync();
            return Ok(products);
        }

        // GET api/Product/5
        [HttpGet("{ProductId:int}", Name = "GetByProductId")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ProductDto>> GetProductId(int ProductId)
        {
            if (ProductId <= 0)
                return BadRequest(ProductId);

            var data = await _productService.GetByIdAsync(ProductId);

            if (data == null)
                return NotFound();

            return Ok(data);
        }

        // POST api/Product
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateProductDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ProductDto>> Post([FromBody] CreateProductDto createProductDto)
        {
            if (createProductDto == null)
                return BadRequest();

            var data = await _productService.AddProductAsync(createProductDto);

            if (data == null)
                return NotFound();

            return Ok(data);
        }

        // PUT api/Product/UpdateProduct/5
        [HttpPut("UpdateProduct/{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Not found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            if (id <= 0)
            {
                return BadRequest(ModelState);
            }

            var _updateCompany = await _productService.UpdateProductQuantity(id,false);

            return Ok(_updateCompany);
        }

        // PUT api/Product/RefreshProduct/5
        [HttpPut("RefreshProduct/{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Not found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RefreshProduct(int id)
        {
            if (id <= 0)
            {
                return BadRequest(ModelState);
            }

            var _updateCompany = await _productService.UpdateProductQuantity(id,true);

            return Ok(_updateCompany);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
