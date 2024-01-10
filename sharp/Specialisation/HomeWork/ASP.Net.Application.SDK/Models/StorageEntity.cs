namespace ASP.Net.Application.SDK.Models
{
    public class StorageEntity : EntityBase
    {
        public virtual IEnumerable<ProductEntity> Products { get; set; }
    }
}
