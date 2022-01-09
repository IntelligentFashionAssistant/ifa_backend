using domain.Entitys;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace persistence;

public static class ContextSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole<long>>().HasData(
                new IdentityRole<long> {Id = 1, Name = "Admin", NormalizedName = "ADMIN".ToUpper()},
                new IdentityRole<long> {Id = 2, Name = "Customer", NormalizedName = "Customer".ToUpper()},
                new IdentityRole<long> {Id = 3, Name = "ShopOwner", NormalizedName = "ShopOwner".ToUpper()}
            );

            var hasher = new PasswordHasher<User>();

            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = 1 , UserName = "admin", Email = "admin@admin.com", NormalizedEmail = "admin@admin.com".ToUpper(), NormalizedUserName = "ADMIN",
                    PasswordHash = hasher.HashPassword(null, "adminadmin")
                }
            );

            modelBuilder.Entity<IdentityUserRole<long>>().HasData(
                new IdentityUserRole<long> {RoleId = 1, UserId = 1}
            );
        }
    }
