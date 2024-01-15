namespace LibraryApi.DataStore
{
    public class BookEntity
    {
        public Guid? Id { get; set; }
        public string Title { get; set; }
        public Guid AuthorId { get; set; }
        public virtual AuthorEntity Author { get; set; }
    }
}
