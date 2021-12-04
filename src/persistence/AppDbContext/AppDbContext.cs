using domain.Entitys;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace persistence
{
    // IdentityDbContext<TUser, TRole, TKey, IdentityUserClaim<TKey>, IdentityUserRole<TKey>,
    // IdentityUserLogin<TKey>, IdentityRoleClaim<TKey>,
    // IdentityUserToken<TKey>> where TUser : IdentityUser<TKey> where TRole : IdentityRole<TKey>
    // where TKey : IEquatable<TKey>
    public class AppDbContext : IdentityDbContext<User,IdentityRole<long>,long>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Property>(entity =>
            {

                entity.HasOne(property => property.Group)
                    .WithMany(property => property.Properties)
                    .HasForeignKey(property => property.GroupId)
                    .OnDelete(DeleteBehavior.NoAction);
                    
                entity.HasOne(property => property.Category)
                   .WithMany(property => property.Properties)
                    .HasForeignKey(property => property.CategoryId)
                   .OnDelete(DeleteBehavior.NoAction);

            });

            //modelBuilder.Entity<Category>()
            //    .HasMany(c => c.Properties)
            //    .WithOne().HasForeignKey(c => c.Id)
            //     .OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<Group>()
            //    .HasMany(c => c.Properties)
            //    .WithOne().HasForeignKey(c => c.Id)
            // .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);


        }

        public DbSet<Category> Categorys { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Garment> Garments { get; set; }
        public DbSet<BodySizes> BodySizes { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Shape> Shapes { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<StoreFeedback> StoreFeedbacks { get; set; }
        public DbSet<User> Users { get; set; }
    }
}