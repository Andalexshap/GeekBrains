namespace LibraryApi.DataStore
{
    public class AuthorEntity
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<BookEntity> Books { get; set; }
    }
}
