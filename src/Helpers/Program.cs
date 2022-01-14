// See https://aka.ms/new-console-template for more information

/****************** constants **********************/

using domain.Entitys;
using Helpers;
using Microsoft.EntityFrameworkCore;


var shape_property = new Dictionary<string, List<string>>()
{
    {"Hourglass", new List<string>(){"v-neck", "property_y", "aölskjfd", "aölkdfj"}},
    {"Triangle", new List<string>(){"property_x", "property_y"}},
    {"shape_x", new List<string>(){"property_x", "property_y"}},
    {"shape_y", new List<string>(){"property_a","property_b" }},
};



/****************** services **********************/
var dbContext = new ApplicationDbContext();


/****************** main **********************/
dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Categorys ON");
foreach(var el in Data.categories)
{
    dbContext.Categorys.Add(el);
}
dbContext.SaveChanges();
dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Categorys OFF");


dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Groups ON");
var category1 = dbContext.Categorys.Single(el => el.Id == 1);
category1.Groups = Data.groups_category1;

var category2 = dbContext.Categorys.Single(el => el.Id == 2);
category2.Groups = Data.groups_category2;

var category3 = dbContext.Categorys.Single(el => el.Id == 3);
category3.Groups = Data.groups_category3;

var category4 = dbContext.Categorys.Single(el => el.Id == 4);
category4.Groups = Data.groups_category4;

var category5 = dbContext.Categorys.Single(el => el.Id == 5);
category5.Groups = Data.groups_category5;

var category6 = dbContext.Categorys.Single(el => el.Id == 6);
category6.Groups = Data.groups_category6;

var category7 = dbContext.Categorys.Single(el => el.Id == 7);
category7.Groups = Data.groups_category7;
dbContext.SaveChanges();
dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Groups OFF");

//shape_property.Values.SelectMany(el => el).Select(el => dbContext.Properties.Add(new Property(){Name = el}));
// foreach (var(shape , properties) in shape_property)
// {
//     var createdShape = dbContext.Shapes.Add(new Shape() {Name = shape});
//     createdShape.Entity.Properties = dbContext.Properties.Where(property => properties.Contains(property.Name)).ToList();
// }
