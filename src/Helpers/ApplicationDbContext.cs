using domain.Entitys;
using Microsoft.EntityFrameworkCore;

namespace Helpers;

public class ApplicationDbContext : DbContext
{
    
    public DbSet<Category> Categorys { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Garment> Garments { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Property> Properties { get; set; }
    public DbSet<Shape> Shapes { get; set; }
        
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=IFA2;User ID=SA;Password=Aamm-1970");
    }
}