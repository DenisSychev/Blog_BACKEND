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
            modelBuilder.Entity<User>();

            modelBuilder.Entity<Publication>(entity =>
            {
                entity.HasOne(pub => pub.User).WithMany(u => u.Publications).HasForeignKey(pub => pub.UserId);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasOne(com => com.User).WithMany(u => u.Comments).HasForeignKey(com => com.UserId);                
            });
        }

    }
}