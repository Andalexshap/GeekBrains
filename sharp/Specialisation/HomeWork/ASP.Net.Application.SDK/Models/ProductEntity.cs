namespace ASP.Net.Application.SDK.Models
{
    public class ProductEntity : EntityBase
    {
        public uint Cost { get; set; }
        public decimal Price { get; set; }
        public Guid? CategoryId { get; set; }
        public virtual CategoryEntity? Category { get; set; }
        public Guid? StorageId { get; set; }
        public virtual StorageEntity? Storage { get; set; }
    }
}
