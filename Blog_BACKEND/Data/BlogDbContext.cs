using Blog_BACKEND.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class BlogDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Publications> Publications { get; set; }

        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(u => u.Publications);
        }


    }
}