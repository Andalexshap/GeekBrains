using LibraryApi.DataStore;
using Microsoft.EntityFrameworkCore;

namespace UserApi.DataStore
{
    public partial class AppDbContext : DbContext
    {
        /*"Host = localhost;Username=postgres;Password=admin;Database=MicroServices"*/
        /*dotnet ef migration add InitialCreate --context UserDbContext*/
        public DbSet<AuthorEntity> Authors { get; set; }
        public DbSet<BookEntity> Books { get; set; }
        private readonly string _connectionString;
        public AppDbContext()
        {
        }

        public AppDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseLazyLoadingProxies().UseNpgsql(_connectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorEntity>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("author_pkey");
                entity.ToTable("authors");
            });
            modelBuilder.Entity<BookEntity>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("book_pkey");
                entity.ToTable("books");
                entity.HasOne(x => x.Author).WithMany(y => y.Books).HasForeignKey(z => z.AuthorId);
            });
            base.OnModelCreating(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
