using Microsoft.EntityFrameworkCore;
using TechTweetAPI.Models.Domain;

namespace TechTweetAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Post> Posts { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
    }
}
