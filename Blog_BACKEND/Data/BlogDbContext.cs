using Blog_BACKEND.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class BlogDbContext : DbContext
    {

        public DbSet<User> User { get; set; }
        public DbSet<Publication> Publication { get; set; }
        public DbSet<Comment> Comment { get; set; }

        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>();

            modelBuilder.Entity<Publication>(entity =>
            {
                entity.Property(e => e.UserId)
                    .HasColumnName("UserId");

                entity.HasOne(pub => pub.User)
                    .WithMany(u => u.Publication)
                    .HasForeignKey(pub => pub.UserId);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(p => p.PublicationId).HasColumnName("PublicationId");



                entity.Property(u => u.UserId).HasColumnName("UserId");

                entity.HasOne(com => com.User).WithMany(u => u.Comment).HasForeignKey(com => com.UserId);
            });
        }


    }
}