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
                new Category { Id = 1, Name = "أثاث", ImageName = "70057997-dd89-4629-97ff-317db877444a.png", Posts = null },
                new Category { Id = 2, Name = "مأكولات", ImageName = "551dfb30-6e08-4f97-b69b-89a2a3f7f509.png", Posts = null },
                new Category { Id = 3, Name = "ملابس", ImageName = "01187183-441a-48f6-9645-9e18514d7047.png", Posts = null }
                );
            modelBuilder.Entity<meal>().HasData(
                new meal { Id = 8, Title = "أكل", Body = "mypost Dess", CategoryId = 3, ImageName = "cfd9d7be-eb03-4176-adc1-0c909d0fd961.png", RestaurantId = 1 }
                );
            modelBuilder.Entity<Restaurant>().HasData(
                new Restaurant { Id = 1, Name = "KFC", Logo = "0a83cc23-0b13-4749-89a1-3469f667175b.png", Image = "2d97e392-4a1c-41be-b879-6b6ac77071a7.png", Address = "الطائف" }
                );
            modelBuilder.Entity<Ads>().HasData(
              new Ads { Id = 1, Image = "70057997-dd89-4629-97ff-317db877444a.png" },
              new Ads { Id = 2, Image = "551dfb30-6e08-4f97-b69b-89a2a3f7f509.png" },
              new Ads { Id = 3, Image = "01187183-441a-48f6-9645-9e18514d7047.png" }
              );
            // modelBuilder.Entity<PostTag>().HasKey(x => new { x.PostId, x.TagId });


            //   modelBuilder.Entity<Tag>().HasData(new Tag { Id = 1, Name = "Sport" }, new Tag { Id = 2, Name = "Angular" });
            base.OnModelCreating(modelBuilder);

        }

        public DbSet<meal> Meals { get; set; }
        //public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        //public DbSet<Tag> Tags { get; set; }
        public DbSet<Ads> Ads { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<order> orders { get; set; }
        public DbSet<Favorite> Favorites { get; set; }

        // public DbSet<PostTag> PostTags { get; set; }
    }
}
