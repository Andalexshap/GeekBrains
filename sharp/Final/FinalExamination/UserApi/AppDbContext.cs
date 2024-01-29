using Microsoft.EntityFrameworkCore;
using WebApiLibrary.DataStore.Entities;

namespace UserApi
{
    public partial class AppDbContext : DbContext
    {
        private readonly string _connectionString;
        public AppDbContext()
        {

        }

        public AppDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        /*
         dotnet ef migrations add InitialCreate --context AppDbContext
         dotnet ef database update
        */
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseLazyLoadingProxies().UseNpgsql(_connectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasIndex(x => x.Email).IsUnique();

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsRequired();

                entity.Property(e => e.Name)
                    .HasMaxLength(255);

                entity.Property(e => e.Price).IsRequired();

                entity.HasOne(x => x.Category)
                    .WithMany(x => x.Products);

                entity.HasOne(x => x.Storage)
                    .WithMany(x => x.Products);
            });
        }
}
