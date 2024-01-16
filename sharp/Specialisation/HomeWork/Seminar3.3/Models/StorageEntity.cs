namespace Seminar3._3.Models
{
    public class StorageEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<ProductEntity> Products { get; set; }
    }
}
