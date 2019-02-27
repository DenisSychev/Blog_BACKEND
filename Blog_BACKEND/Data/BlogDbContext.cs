using Blog_BACKEND.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class BlogDbContext : DbContext
    {

        public DbSet<User> User { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");
            });

            modelBuilder.Entity<Publication>(entity =>
            {
                entity.ToTable("Publication");
                entity.HasOne(pub => pub.Author).WithMany(u => u.Publications).HasForeignKey(pub => pub.UserId);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");
                entity.HasOne(com => com.Author).WithMany(u => u.Comments).HasForeignKey(com => com.UserId);
                entity.HasOne(com => com.Publication).WithMany(pub => pub.Comments).HasForeignKey(com => com.PublicationId);             
            });
        }

    }
}