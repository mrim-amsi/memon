using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Web_Application_with_Identity.Models;

namespace Web_Application_with_Identity
{
    public class AppDBContext : IdentityDbContext
    {
        private readonly DbContextOptions _options;

        public AppDBContext(DbContextOptions options) : base(options)
        {
            _options = options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "مأكولات" },
                new Category { Id = 2, Name = "ملابس" },
                new Category { Id = 3, Name = "أثاث" }
                );

            modelBuilder.Entity<PostTag>().HasKey(x => new { x.PostId, x.TagId });


            modelBuilder.Entity<Tag>().HasData(new Tag { Id = 1, Name = "Sport" }, new Tag { Id = 2, Name = "Angular" });
            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public DbSet<PostTag> PostTags { get; set; }
    }
}
