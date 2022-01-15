using Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Propertys;

namespace api.Controllers;


[ApiController]
[Route("/seed")]
public class SeedController : Controller
{
    private AppDbContext _dbContext;
    public SeedController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost("categories")]
    public IActionResult InsertDataIntoDataBase()
    {

        using (var transaction = _dbContext.Database.BeginTransaction())
        {
            _dbContext.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT dbo.Categorys ON");
            foreach (var el in Data.categories)
            {
                var res = _dbContext.Categorys.Add(el);
            }

            _dbContext.SaveChanges();
            _dbContext.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT dbo.Categorys OFF");

            transaction.Commit();
        }

        return Ok();
    }
}
