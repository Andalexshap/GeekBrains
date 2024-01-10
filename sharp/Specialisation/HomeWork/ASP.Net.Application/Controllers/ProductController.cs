using ASP.Net.Application.SDK.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Net.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpGet("products")]
        public IActionResult GetProducts()
        {
            var products = new List<ProductEntity>();
            try
            {
                using (var context = new SDK.AppContext())
                {
                    var entities = context.Products.Select(x => new ProductEntity
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Description = x.Description
                    });
                    products.AddRange(entities);
                }
            }
            catch
            {
                return StatusCode(500);
            }
            return Ok(products);
        }

        [HttpGet("product/{id}")]
        public IActionResult GetProduct(Guid id)
        {
            var product = new ProductEntity();
            try
            {
                using (var context = new SDK.AppContext())
                {
                    var entity = context.Products.FirstOrDefault(x => x.Id == id);

                    product = new ProductEntity()
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        Description = entity.Description
                    };
                }
            }
            catch
            {
                return StatusCode(500);
            }
            return Ok(product);
        }

        [HttpPost("product")]
        public IActionResult SaveProduct([FromQuery]
            string name,
            string description,
            Guid categoryId,
            Guid storageId)
        {
            Guid result = Guid.Empty;

            try
            {
                using (var context = new SDK.AppContext())
                {
                    if (!context.Products.Any(x => x.Name.ToLower().Equals(name.ToLower())))
                    {
                        var product = new ProductEntity()
                        {
                            Id = Guid.NewGuid(),
                            Name = name,
                            Description = description,
                            CategoryId = categoryId,
                            StorageId = storageId
                        };

                        context.Add(product);
                        context.SaveChanges();
                        result = product.Id;

                        return Ok(result);
                    }
                }
            }
            catch
            {
                return StatusCode(500);
            }
            return Ok(result);
        }

        [HttpPost("set_price")]
        public IActionResult SetPrice([FromQuery]
            Guid ProductId,
            decimal price)
        {
            try
            {
                using (var context = new SDK.AppContext())
                {
                    var product = context.Products.FirstOrDefault(x => x.Id == ProductId);
                    if (product != null)
                    {
                        product.Price = price;
                        context.SaveChanges();

                        return Ok();
                    }
                    return StatusCode(404);
                }
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost("add_count")]
        public IActionResult AddCount([FromQuery]
            Guid ProductId,
            int newCount)
        {
            try
            {
                using (var context = new SDK.AppContext())
                {
                    var product = context.Products.FirstOrDefault(x => x.Id == ProductId);
                    if (product != null && newCount > 0)
                    {
                        product.Cost += (uint)newCount;
                        context.SaveChanges();

                        return Ok();
                    }
                    return StatusCode(404);
                }
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
                using (var context = new SDK.AppContext())
                {
                    var product = context.Products.FirstOrDefault(x => x.Id == productId);
                    if (product != null)
                    {
                        context.Products.Remove(product);
                        context.SaveChanges();

                        return Ok();
                    }
                    return StatusCode(404);
                }
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
