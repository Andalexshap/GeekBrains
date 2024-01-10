using ASP.Net.Application.SDK.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.Net.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        [HttpGet("categories")]
        public IActionResult GetCategories()
        {
            var categories = new List<CategoryEntity>();
            try
            {
                using (var context = new SDK.AppContext())
                {
                    var entities = context.Categories.Select(x => new CategoryEntity
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Description = x.Description
                    });
                    categories.AddRange(entities);
                }
            }
            catch
            {
                return StatusCode(500);
            }
            return Ok(categories);
        }

        [HttpGet("caegory/{id}")]
        public IActionResult GetCategory(Guid id)
        {
            var category = new CategoryEntity();
            try
            {
                using (var context = new SDK.AppContext())
                {
                    var entity = context.Categories.FirstOrDefault(x => x.Id == id);

                    category = new CategoryEntity()
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
            return Ok(category);
        }

        [HttpPost("category")]
        public IActionResult SaveCategory([FromQuery]
                string name,
            string description)
        {
            Guid result = Guid.Empty;

            try
            {
                using (var context = new SDK.AppContext())
                {
                    if (!context.Categories.Any(x => x.Name.ToLower().Equals(name.ToLower())))
                    {
                        var category = new CategoryEntity()
                        {
                            Id = Guid.NewGuid(),
                            Name = name,
                            Description = description,
                        };

                        context.Categories.Add(category);
                        context.SaveChanges();
                        result = category.Id;

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

        [HttpPost("add_product")]
        public IActionResult AddProduct([FromQuery]
            Guid categoryId,
            Guid productId)
        {
            try
            {
                using (var context = new SDK.AppContext())
                {
                    var category = context.Categories.FirstOrDefault(x => x.Id == categoryId);
                    var product = context.Products.FirstOrDefault(x => x.Id == productId);
                    if (category != null && product != null)
                    {

                        context.Categories.SingleOrDefault(x => x.Products.Select(x => x.Id).Contains(productId))?.Products.Remove(product);

                        category.Products.Add(product);
                        product.CategoryId = categoryId;
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

        [HttpDelete("{categoryId}")]
        public IActionResult DeleteProduct(Guid categoryId)
        {
            try
            {
                using (var context = new SDK.AppContext())
                {
                    var category = context.Categories.FirstOrDefault(x => x.Id == categoryId);
                    if (category != null)
                    {
                        context.Categories.Remove(category);

                        context.Products.Where(x => x.CategoryId == categoryId)
                            .ForEachAsync(x =>
                            {
                                x.CategoryId = null;
                                x.Category = null;
                            });

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
