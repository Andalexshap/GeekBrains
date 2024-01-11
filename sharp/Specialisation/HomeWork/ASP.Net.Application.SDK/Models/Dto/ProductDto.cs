namespace ASP.Net.Application.SDK.Models
{
    public class ProductDto : BaseDto
    {
        public uint Cost { get; set; }
        public decimal Price { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? StorageId { get; set; }


    }
}
