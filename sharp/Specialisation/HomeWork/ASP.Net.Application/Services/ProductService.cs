using ASP.Net.Application.Interfaces;
using ASP.Net.Application.SDK.Models;
using ASP.Net.Application.SDK.Utils;

namespace ASP.Net.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly SDK.AppDbContext _context;

        public ProductService(SDK.AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<ProductDto> GetProducts()
        {
            var products = new List<ProductDto>();

            using (_context)
            {
                var dto = _context.Products.Select(x => x.ConvertToDto());
                products.AddRange(dto);
            }
            return products;
        }


        public ProductDto? GetProduct(Guid id)
        {
            using (_context)
            {
                return _context.Products.FirstOrDefault(x => x.Id == id)?.ConvertToDto();
            }
        }

        public Guid SaveProduct(ProductDto product)
        {
            if (product.Id == null)
                product.Id = Guid.NewGuid();

            using (_context)
            {
                if (!_context.Products.Any(x => x.Name.ToLower().Equals(product.Name.ToLower())))
                {
                    var entity = product.ConvertToEntity();
                    _context.Products.Add(entity);
                    _context.SaveChanges();
                }
            }
            return (Guid)product.Id;
        }

        public void SetPrice(Guid ProductId, decimal price)
        {
            using (_context)
            {
                var product = _context.Products.FirstOrDefault(x => x.Id == ProductId);
                if (product != null)
                {
                    product.Price = price;
                    _context.SaveChanges();
                }
            }
        }

        public void AddCount(Guid ProductId, int addCount)
        {
            using (_context)
            {
                var product = _context.Products.FirstOrDefault(x => x.Id == ProductId);
                if (product != null && addCount > 0)
                {
                    product.Cost += (uint)addCount;
                    _context.SaveChanges();
                }
            }
        }

        public void DeleteProduct(Guid productId)
        {
            using (_context)
            {
                var product = _context.Products.FirstOrDefault(x => x.Id == productId);
                if (product != null)
                {
                    _context.Products.Remove(product);
                    _context.SaveChanges();
                }
            }
        }
    }
}
