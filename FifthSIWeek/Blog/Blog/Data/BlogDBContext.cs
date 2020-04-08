using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data
{
    public class BlogDBContext : DbContext
    {
        public BlogDBContext(DbContextOptions<BlogDBContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // we could add a ModelBuilderExtension class with a Seed() method to initialize some data
            modelBuilder.Entity<User>().HasData(new User { Id=1, FirstName="Anna", LastName="Czinege"},
                new User { Id = 2, FirstName = "Eszter", LastName = "Mázi" },
                new User { Id = 3, FirstName = "Norbert", LastName = "Benkó" });
        }

    }
}
