using Seminar3._3.Models.Dto;

namespace Seminar3._3.Abstractions
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetProducts();
        int AddProduct(ProductDto product);
    }
}
