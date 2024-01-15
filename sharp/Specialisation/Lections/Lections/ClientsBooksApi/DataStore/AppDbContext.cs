using Microsoft.EntityFrameworkCore;

namespace ClientsBooksApi.DataStore
{
    public partial class AppDbContext : DbContext
    {
        /*"Host = localhost;Username=postgres;Password=admin;Database=MicroServices"*/
        /*dotnet ef migration add InitialCreate --context UserDbContext*/
        public DbSet<ClientBookEntity> ClientBooks { get; set; }
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
            modelBuilder.Entity<ClientBookEntity>(entity =>
            {
                entity.HasKey(e => e.BookId).HasName("book_key");
                entity.ToTable("clientbooks");
                entity.Property(x => x.ClientId).HasColumnName("ClientId");
                entity.Property(x => x.BookId).HasColumnName("BookId");
            });

            base.OnModelCreating(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
