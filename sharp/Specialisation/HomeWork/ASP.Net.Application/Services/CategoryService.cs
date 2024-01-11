using ASP.Net.Application.Interfaces;
using ASP.Net.Application.SDK.Models;
using ASP.Net.Application.SDK.Utils;

namespace ASP.Net.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly SDK.AppDbContext _context;

        public CategoryService(SDK.AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CategoryDto> GetCategories()
        {
            using (_context)
                return _context.Categories.Select(x => x.ConvertToDto()).ToList();
        }

        public CategoryDto? GetCategory(Guid id)
        {
            using (_context)
                return _context.Categories.FirstOrDefault(x => x.Id == id)?.ConvertToDto();
        }

        public Guid SaveCategory(CategoryDto category)
        {

            using (_context)
            {
                if (!_context.Categories.Any(x => x.Name.ToLower().Equals(category.Name.ToLower())))
                {
                    if (category.Id == null)
                        category.Id = Guid.NewGuid();

                    _context.Categories.Add(category.ConvertToEntity());
                    _context.SaveChanges();
                    return (Guid)category.Id;
                }
            }
            return Guid.Empty;
        }

        public bool AddProduct(Guid categoryId, Guid productId)
        {
            using (_context)
            {
                var category = _context.Categories.FirstOrDefault(x => x.Id == categoryId);
                var product = _context.Products.FirstOrDefault(x => x.Id == productId);
                if (category != null && product != null)
                {

                    _context.Categories.SingleOrDefault(x => x.Products.Select(x => x.Id).Contains(productId))?.Products.Remove(product);

                    category.Products.Add(product);
                    product.CategoryId = categoryId;
                    _context.SaveChanges();

                    return true;
                }
                return false;
            }
        }

        public bool DeleteCategory(Guid categoryId)
        {
            using (_context)
            {
                var category = _context.Categories.FirstOrDefault(x => x.Id == categoryId);
                if (category != null)
                {
                    _context.Categories.Remove(category);

                    _context.Products.Where(x => x.CategoryId == categoryId).ToList()
                        .ForEach(x =>
                        {
                            x.CategoryId = null;
                            x.Category = null;
                        });

                    _context.SaveChanges();

                    return true;
                }
                return false;
            }
        }
    }
}
