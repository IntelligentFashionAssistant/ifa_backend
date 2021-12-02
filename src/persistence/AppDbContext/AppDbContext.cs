using domain.Entitys;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace repository
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> optionsBuilderOptions)
        {
            throw new System.NotImplementedException();
        }

        public DbSet<Category> Categorys { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Garment> Garments { get; set; }
        public DbSet<BodySizes> BodySizes { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyFeedback> PropertyFeedbacks { get; set; }
        public DbSet<Shape> Shapes { get; set; }
        public DbSet<Shape_Property> Shape_Properties { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<StoreFeedback> StoreFeedbacks { get; set; }
        public DbSet<User> Users { get; set; }
    }
}