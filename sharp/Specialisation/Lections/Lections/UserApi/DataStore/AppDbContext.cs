using Microsoft.EntityFrameworkCore;

namespace UserApi.DataStore
{
    public partial class AppDbContext : DbContext
    {
        /*"Host = localhost;Username=postgres;Password=admin;Database=MicroServices"*/
        /*dotnet ef migrations add InitialCreate --context UserDbContext*/
        public DbSet<UserEntity> Users { get; set; }
        private readonly string _connectionString;
        public AppDbContext()
        {
        }

        public AppDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(_connectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.HasKey(e => e.Email).HasName("user_pkey");
                entity.HasIndex(e => e.Email).IsUnique();
                entity.ToTable("users");
            });
            base.OnModelCreating(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
