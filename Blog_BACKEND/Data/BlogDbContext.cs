using Blog_BACKEND.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class BlogDbContext : DbContext
    {

        public DbSet<User> User { get; set; }
        public DbSet<Publication> Publication { get; set; }

        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(i => i.Publication).HasColumnName("");
            });

            modelBuilder.Entity<Publication>(entity =>
            {
                entity.Property(e => e.UserId)
                    .HasColumnName("UserId");

                entity.HasOne(pub => pub.User)
                    .WithMany(u => u.Publication)
                    .HasForeignKey(pub => pub.UserId);
            });
        }


    }
}