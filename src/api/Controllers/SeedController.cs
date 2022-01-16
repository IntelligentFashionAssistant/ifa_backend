using domain.Entitys;
using Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Propertys;

namespace api.Controllers;


[ApiController]
[Route("/seed")]
public class SeedController : Controller
{
    private AppDbContext _dbContext;
    private readonly UserManager<User> _userManager;

    public SeedController(AppDbContext dbContext, UserManager<User> userManager)
    {
        _dbContext = dbContext;
        _userManager = userManager;
    }

        [HttpPost("categories")]
        public IActionResult InsertDataIntoDataBaseCategories()
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

        [HttpPost("groups")]
        public IActionResult InsertDataIntoDataBasegroups()
        {

            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                _dbContext.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT dbo.groups ON");
                foreach (var (group, categoryIds) in Data.groups_categories)
                {
                    group.Categories =  categoryIds
                        .Select(id => _dbContext.Categorys.Single(category => category.Id == id)).ToList();
                    _dbContext.Groups.Add(group);
                }
           
                _dbContext.SaveChanges();
                _dbContext.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT dbo.groups OFF");
                transaction.Commit();
            }
            return Ok();
        }

       [HttpPost("colors")]
       public IActionResult InsertDataIntoDataBaseColors()
    {

        using (var transaction = _dbContext.Database.BeginTransaction())
        {
            _dbContext.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT dbo.Colors ON");
            foreach (var el in Data.colors)
            {
                var res = _dbContext.Colors.Add(el);
            }

            _dbContext.SaveChanges();
            _dbContext.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT dbo.Colors OFF");

            transaction.Commit();
        }

        return Ok();
    }

       [HttpPost("sizes")]
       public IActionResult InsertDataIntoDataBaseSizes()
    {

        using (var transaction = _dbContext.Database.BeginTransaction())
        {
            _dbContext.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT dbo.Sizes ON");
            foreach (var el in Data.sizes)
            {
                var res = _dbContext.Sizes.Add(el);
            }

            _dbContext.SaveChanges();
            _dbContext.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT dbo.Sizes OFF");

            transaction.Commit();
        }

        return Ok();
    }

    [HttpPost("users")]
    public async Task<IActionResult> InsertDataIntoDataBaseUsers()
    {

           foreach(var user in Data.users)
        {
               var res = await _userManager.CreateAsync(user,"Store1997@@##");

            if (res.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "SHOPOWNER");
            }
        }
       

        return Ok();
    }

    [HttpPost("stores")]
    public IActionResult InsertDataIntoDataBaseStores()
    {

        using (var transaction = _dbContext.Database.BeginTransaction())
        {
            _dbContext.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT dbo.Stores ON");
            foreach (var el in Data.stores)
            {
                var res = _dbContext.Stores.Add(el);
            }

            _dbContext.SaveChanges();
            _dbContext.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT dbo.Stores OFF");

            transaction.Commit();
        }

        return Ok();
    }

    [HttpPost("locations")]
    public IActionResult InsertDataIntoDataBaseLocations()
    {

        using (var transaction = _dbContext.Database.BeginTransaction())
        {
            _dbContext.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT dbo.Locations ON");
            foreach (var el in Data.locations)
            {
                var res = _dbContext.Locations.Add(el);
            }

            _dbContext.SaveChanges();
            _dbContext.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT dbo.Locations OFF");

            transaction.Commit();
        }

        return Ok();
    }


    [HttpPost("property")]
    public IActionResult InsertDataIntoDataBaseProperties()
    {
        using (var transaction = _dbContext.Database.BeginTransaction())
        {
            _dbContext.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT dbo.Properties ON");
            foreach (var el in Data.properties)
            {
                var res = _dbContext.Properties.Add(el);
            }

            _dbContext.SaveChanges();
            _dbContext.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT dbo.Properties OFF");

            transaction.Commit();
        }
        return Ok();
    }
    
    
    
    [HttpPost("shape")]
    public IActionResult InsertDataIntoDataBaseShape()
    {
        
        // using (var transaction = _dbContext.Database.BeginTransaction())
        // {
            // _dbContext.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT dbo. ON");
            int x = 0, y = 0;
            foreach (var (shapeName, propertyNames) in Data.shapes)
            {
                foreach (var propertyName in propertyNames)
                {
                    if (_dbContext.Properties.SingleOrDefault(el => el.Name.ToLower().Equals(propertyName.ToLower())) == null)
                    {
                        y++;
                    }
                    else
                    {
                        x++;
                    }
                }
            }
       
            // _dbContext.SaveChanges();
            // _dbContext.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT dbo.groups OFF");
            // transaction.Commit();
        // }
        return Ok(new {X=x, Y=y});
    }
    
    
    [HttpPost("garment")]
    public IActionResult InsertDataIntoDataBaseGarment()
    {
        
        return Ok();
    }
}
