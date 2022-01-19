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
               var res = await _userManager.CreateAsync(user,"Store1997@@");

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

        //using (var transaction = _dbContext.Database.BeginTransaction())
        //{
           // _dbContext.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT dbo.Locations ON");
            foreach (var el in Data.locations)
            {
                var res = _dbContext.Locations.Add(el);
            }

            _dbContext.SaveChanges();
         //  _dbContext.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT dbo.Locations OFF");

          //  transaction.Commit();
        //}

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
            foreach (var (shapeName, propertyNames) in Data.shapes)
            {
 
                Shape shape = new Shape()
            {
                Name = shapeName,

            };
                foreach (var propId in propertyNames)
                {
                shape.Properties.Add(_dbContext.Properties.Single(property => property.Id == propId));
                }
               _dbContext.Shapes.Add(shape);
        }

             _dbContext.SaveChanges();
            // _dbContext.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT dbo.groups OFF");
            // transaction.Commit();
        // }
        return Ok();
    }
    
    
    [HttpPost("garment")]
    public IActionResult InsertDataIntoDataBaseGarment()
    {

        using (var transaction = _dbContext.Database.BeginTransaction())
        {
            _dbContext.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT dbo.Garments ON");
            foreach (var el in Data.garments)
            {
                el.Description = "Garment Description";
                var res = _dbContext.Garments.Add(el);
            }

            _dbContext.SaveChanges();
            _dbContext.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT dbo.Garments OFF");

            transaction.Commit();
        }

        return Ok();
    }

    [HttpPost("garmentProperty")]
    public IActionResult InsertDataIntoDataBaseGarmentProperty()
    {
        foreach (var el in Data.garment_property)
        {
            var property = _dbContext.Properties.Single(property => property.Id == el[1]);
            var garment = _dbContext.Garments.Single(garment => garment.Id == el[0]);
            
            garment.Properties.Add(property);
        }

        _dbContext.SaveChanges();

        return Ok();
    }

    [HttpPost("image")]
    public IActionResult InsertDataIntoDataBaseImage()
    {

        using (var transaction = _dbContext.Database.BeginTransaction())
        {
            _dbContext.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT dbo.Images ON");
            foreach (var img in Data.images)
            {
                _dbContext.Images.Add(img);
            }

            _dbContext.SaveChanges();
            _dbContext.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT dbo.Images OFF");
            transaction.Commit();
        }
        return Ok();
    }


    [HttpPost("garmentColor")]
    public IActionResult InsertDataIntoDataBaseGarmentColor()
    {
        foreach (var (garmentId,colorIds) in Data.colors_garments)
        {

            var colors = colorIds.Select(colorId => _dbContext.Colors.Single(color => color.Id == colorId)).ToList();
           
            var garment = _dbContext.Garments.Single(garment => garment.Id == garmentId);

            garment.Colors = colors;
        }

        _dbContext.SaveChanges();

        return Ok();
    }

    [HttpPost("garmentSize")]
    public IActionResult InsertDataIntoDataBaseGarmentSize()
    {
        Random rand = new Random();
        var garments = _dbContext.Garments.ToList();
        var sizes = _dbContext.Sizes.AsEnumerable().GroupBy(x => x.CategoryId)
                   .ToDictionary(el => el.Key, el => el.ToList());


        foreach (var garment in garments)
        {
            foreach(var (categoryId, listOfSizes) in sizes)
            {
                
                if(garment.CategoryId == categoryId)
                {
                    var temp = new List<long>();
                    var index = rand.Next(1,listOfSizes.Count);
                    for (var i = 0; i < index; i++) 
                    {
                        var e = rand. Next(1 ,listOfSizes.Count);
                        if(!temp.Contains(e))
                        {
                            garment.Sizes.Add(listOfSizes[e]);
                            temp.Add(e);

                        }

                    }
                }
            }
        }

        _dbContext.SaveChanges();

        return Ok();
    }

    [HttpPost("AddData")]
    public async Task<IActionResult> AddData()
    {
        this.InsertDataIntoDataBaseCategories();
        this.InsertDataIntoDataBaseColors();
        this.InsertDataIntoDataBasegroups();
        this.InsertDataIntoDataBaseProperties();
        this.InsertDataIntoDataBaseSizes();
        await this.InsertDataIntoDataBaseUsers();
        this.InsertDataIntoDataBaseStores();
        this.InsertDataIntoDataBaseLocations();
        this.InsertDataIntoDataBaseShape();
        this.InsertDataIntoDataBaseGarment();
        this.InsertDataIntoDataBaseGarmentColor();
        this.InsertDataIntoDataBaseGarmentProperty();
        this.InsertDataIntoDataBaseImage();
        return Ok();
    }
}
