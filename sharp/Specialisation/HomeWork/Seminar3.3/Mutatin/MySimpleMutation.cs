using Seminar3._3.Abstractions;
using Seminar3._3.Models.Dto;

namespace Seminar3._3.Mutatin
{
    public class MySimpleMutation
    {
        public int AddProduct(ProductDto product, [Service] IProductService service)
        {
            var id = service.AddProduct(product);
            return id;
        }
    }
}
