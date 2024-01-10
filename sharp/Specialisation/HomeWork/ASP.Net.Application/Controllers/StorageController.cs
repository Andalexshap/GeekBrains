using System.Data.Entity;
using ASP.Net.Application.SDK.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Net.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StorageController : ControllerBase
    {
        [HttpGet("storages")]
        public IActionResult GetStorages()
        {
            var storages = new List<StorageEntity>();
            try
            {
                using (var context = new SDK.AppContext())
                {
                    var entities = context.Storages.Select(x => new StorageEntity
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Description = x.Description
                    });
                    storages.AddRange(entities);
                }
            }
            catch
            {
                return StatusCode(500);
            }
            return Ok(storages);
        }

        [HttpGet("storage/{id}")]
        public IActionResult GetStorage(Guid id)
        {
            var storage = new StorageEntity();
            try
            {
                using (var context = new SDK.AppContext())
                {
                    var entity = context.Storages.FirstOrDefault(x => x.Id == id);

                    storage = new StorageEntity()
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
            return Ok(storage);
        }

        [HttpPost("storage")]
        public IActionResult SaveCategory([FromQuery]
                string name,
            string description)
        {
            Guid result = Guid.Empty;

            try
            {
                using (var context = new SDK.AppContext())
                {
                    if (!context.Storages.Any(x => x.Name.ToLower().Equals(name.ToLower())))
                    {
                        var storage = new StorageEntity()
                        {
                            Id = Guid.NewGuid(),
                            Name = name,
                            Description = description,
                        };

                        context.Storages.Add(storage);
                        context.SaveChanges();
                        result = storage.Id;

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
        public IActionResult AddStorage([FromQuery]
            Guid storageId,
            Guid productId)
        {
            try
            {
                using (var context = new SDK.AppContext())
                {
                    var category = context.Storages.FirstOrDefault(x => x.Id == storageId);
                    var product = context.Products.FirstOrDefault(x => x.Id == productId);
                    if (category != null && product != null)
                    {

                        context.Storages.SingleOrDefault(x => x.Products.Select(x => x.Id).Contains(productId))?.Products.Remove(product);

                        category.Products.Add(product);
                        product.StorageId = storageId;
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

        [HttpDelete("{storageId}")]
        public IActionResult DeleteProduct(Guid storageId)
        {
            try
            {
                using (var context = new SDK.AppContext())
                {
                    var storage = context.Storages.FirstOrDefault(x => x.Id == storageId);
                    if (storage != null)
                    {
                        context.Storages.Remove(storage);

                        context.Products.Where(x => x.StorageId == storageId)
                            .ForEachAsync(x =>
                            {
                                x.StorageId = null;
                                x.Storage = null;
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
