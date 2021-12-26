// See https://aka.ms/new-console-template for more information

/****************** constants **********************/

using domain.Entitys;
using Helpers;



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
//shape_property.Values.SelectMany(el => el).Select(el => dbContext.Properties.Add(new Property(){Name = el}));
foreach (var(shape , properties) in shape_property)
{
    var createdShape = dbContext.Shapes.Add(new Shape() {Name = shape});
    createdShape.Entity.Properties = dbContext.Properties.Where(property => properties.Contains(property.Name)).ToList();
}
