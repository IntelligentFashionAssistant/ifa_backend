using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using persistence;

namespace persistence
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=TheTop;User ID=SA;Password=Aamm-1970");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
