namespace ASP.Net.Application.SDK.Models
{
    public class CategoryEntity : EntityBase
    {
        public virtual IEnumerable<ProductEntity?> Products { get; set; }
    }
}
