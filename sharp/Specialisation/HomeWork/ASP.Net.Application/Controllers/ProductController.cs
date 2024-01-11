using ASP.Net.Application.Interfaces;
using ASP.Net.Application.SDK.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Net.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("products")]
        public IActionResult GetProducts()
        {
            try
            {
                var response = _productService.GetProducts();
                return Ok(response);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("product/{id}")]
        public IActionResult GetProduct(Guid id)
        {
            try
            {
                var product = _productService.GetProduct(id);
                return Ok(product);
            }
            catch
            {
                return StatusCode(500);
            }
            return StatusCode(404);
        }

        [HttpPost("product")]
        public IActionResult SaveProduct([FromBody] ProductDto product)
        {
            try
            {
                var result = _productService.SaveProduct(product);
                return Ok(result);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost("set_price")]
        public IActionResult SetPrice([FromQuery] Guid productId, decimal price)
        {
            try
            {
                _productService.SetPrice(productId, price);
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost("add_count")]
        public IActionResult AddCount([FromQuery] Guid productId, int newCount)
        {
            try
            {
                _productService.AddCount(productId, newCount);
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{productId}")]
        public IActionResult DeleteProduct(Guid productId)
        {
            try
            {
                _productService.DeleteProduct(productId);
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
