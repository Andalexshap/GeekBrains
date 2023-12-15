using Microsoft.EntityFrameworkCore;
using Seminar_2_5.Entities;

namespace Seminar_2_5
{
    internal class ChatContext : DbContext
    {
        DbSet<UserEntity> Users { get; set; }
        DbSet<MessageEntity> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=myDataBase;User Id=admin;Password=admin;");
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.HasKey(x => x.Id).HasName("user_pkey");
                entity.ToTable("Users");
                entity.Property(e => e.FullName).HasColumnName("FullName");
            });


            modelBuilder.Entity<MessageEntity>(entity =>
            {
                entity.HasKey(x => x.Id).HasName("message_pkey");
                entity.ToTable("message");
                entity.Property(e => e.Text).HasColumnName("Text");
            });
        }

        public ChatContext()
        {

        }
    }
}
