using ASP.Net.Application.Interfaces;
using ASP.Net.Application.SDK.Models;
using ASP.Net.Application.SDK.Utils;

namespace ASP.Net.Application.Services
{
    public class StorageService : IStorageService
    {
        private readonly SDK.AppDbContext _context;

        public StorageService(SDK.AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<StorageDto> GetStorages()
        {
            using (_context)
                return _context.Storages.Select(x => x.ConvertToDto()).ToList();
        }

        public StorageDto? GetStorage(Guid id)
        {
            using (_context)
                return _context.Storages.FirstOrDefault(x => x.Id == id)?.ConvertToDto();
        }

        public Guid SaveCategory(StorageDto storage)
        {
            using (_context)
            {
                if (storage.Id == null)
                    storage.Id = Guid.NewGuid();
                if (!_context.Storages.Any(x => x.Name.ToLower().Equals(storage.Name.ToLower())))
                {
                    _context.Storages.Add(storage.ConvertToEntity());
                    _context.SaveChanges();

                    return (Guid)storage.Id;
                }
                return Guid.Empty;
            }
        }

        public bool AddProduct(Guid storageId, Guid productId)
        {
            using (_context)
            {
                var category = _context.Storages.FirstOrDefault(x => x.Id == storageId);
                var product = _context.Products.FirstOrDefault(x => x.Id == productId);
                if (category != null && product != null)
                {

                    _context.Storages.SingleOrDefault(x => x.Products.Select(x => x.Id).Contains(productId))?.Products.Remove(product);

                    category.Products.Add(product);
                    product.StorageId = storageId;
                    _context.SaveChanges();

                    return true;
                }
                return false;
            }
        }

        public bool DeleteStorage(Guid storageId)
        {
            using (_context)
            {
                var storage = _context.Storages.FirstOrDefault(x => x.Id == storageId);
                if (storage != null)
                {
                    _context.Storages.Remove(storage);

                    _context.Products.Where(x => x.StorageId == storageId).ToList()
                        .ForEach(x =>
                        {
                            x.StorageId = null;
                            x.Storage = null;
                        });

                    _context.SaveChanges();

                    return true;
                }
                return false;
            }
        }
    }
}
