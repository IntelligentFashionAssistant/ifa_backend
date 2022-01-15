using domain.Entitys;

namespace Helpers;

public class Data
{
    public static List<Category> categories = new List<Category>()
    {
        new Category() {Id = 1, Name = "Skirt", Description = "the lower part of human"},
        new Category() {Id = 2, Name = "Dress", Description = "Dresses that women wear"},
        new Category() {Id = 4, Name = "Pants", Description = "like jeans "},
        new Category() {Id = 5, Name = "Top", Description = "like blouse"},
        new Category() {Id = 7, Name = "Jumpsuit", Description = "Also known as playsuits"}
    };


    public static List<Group> groups_category1 = new List<Group>()
    {
        new Group() {Id = 1, Name = "Details", Description = "Any specific detail", Categories = new List<Category>{ new Category {Id = 1}} },
        new Group()
        {
            Id = 2, Name = "Hemline", Description = "the level of the lower edge of a garment such as a skirt",Categories = new List<Category>{ new Category {Id = 1}}
        },
        new Group() {Id = 3, Name = "Style", Description = "the style or specific design",Categories = new List<Category>{ new Category {Id = 1}}},
    };

    public static List<Group> groups_category2 = new List<Group>()
    {
        new Group() {Id = 6, Name = "Style", Description = "Design"},
        new Group() {Id = 7, Name = "Details", Description = "Special adds on the garment such as mesh or buttons"},
        new Group() {Id = 8, Name = "Waistline", Description = "line encircling the narrowest part of the wais"},
        new Group() {Id = 9, Name = "Height", Description = "length of a dress"},
        new Group() {Id = 10, Name = "Neckline", Description = "the shape of a garment near the woman's neck"},
        new Group() {Id = 11, Name = "Sleeve", Description = "Sleeve of a dress"},
    };

    public static List<Group> groups_category3 = new List<Group>()
    {
        new Group() {Id = 4, Name = "Style", Description = "Design of the back of the garment"},
        new Group() {Id = 5, Name = "Details", Description = "Such as buttons extra fabric or mesh"},
    };

    public static List<Group> groups_category4 = new List<Group>()
    {
        new Group() {Id = 12, Name = "Slacks", Description = "loose wide pants"},
        new Group() {Id = 13, Name = "Jeans", Description = "jeans"},
        new Group() {Id = 14, Name = "Hemline", Description = "till where the end of a pants reach"},
        new Group() {Id = 31, Name = "waist line", Description = "waist line"}
    };


    public static List<Group> groups_category6 = new List<Group>()
    {
        new Group() {Id = 15, Name = "Details", Description = "Ex : Floral print"},
        new Group() {Id = 16, Name = "Sleeve", Description = "sleeve of a top garment"},
        new Group() {Id = 17, Name = "Neckline", Description = "shape of a garment near the neck"},
        new Group() {Id = 18, Name = "Fabric", Description = "the material a garment is made of"},
        new Group() {Id = 27, Name = "Shoulder", Description = "Design of the Shoulder"}
    };

    public static List<Group> groups_category5 = new List<Group>()
    {
        new Group() {Id = 19, Name = "Style", Description = "Design"},
        new Group() {Id = 20, Name = "Sleeve", Description = "Sleeve of a top garment"},
        new Group() {Id = 21, Name = "Neckline", Description = "the shape of a garment near the neck"},
        new Group() {Id = 22, Name = "Details", Description = "Special extras on a top Eg: mesh"},
        new Group() {Id = 23, Name = "Pattern", Description = "Eg: karo"},
        new Group() {Id = 24, Name = "Cinched", Description = "tight from the neck area"},
        new Group() {Id = 25, Name = "Fabric", Description = "material the garment is made of"},
        new Group() {Id = 26, Name = "Hemline", Description = "till where the garment end on the waist"},
        new Group() {Id = 28, Name = "Shoulder", Description = "How the garment is attached on the shoulder"}
    };

    public static List<Group> groups_category7 = new List<Group>()
    {
        new Group() {Id = 29, Name = "Style", Description = "style"},
        new Group() {Id = 30, Name = "Details", Description = "details"}
    };

    public static List<Property> properties = new List<Property>()
    {
        new Property() {Id = 1, Name = "ankle", Description = "pants till  ankle", GroupId = 1},
        new Property() {Id = 3, Name = "Mesh", Description = "Type of fabric details", GroupId = 18},
        new Property()
            {Id = 5, Name = "Tulip back ", Description = "tulip cut in the back of the top garment", GroupId = 4},
        new Property()
            {Id = 6, Name = "V back", Description = "V open shape from the back of the top garment", GroupId = 4},
        new Property()
            {Id = 7, Name = "Y Back", Description = "Y shaped open in the back of the top garment", GroupId = 4},
        new Property()
            {Id = 12, Name = "A line", Description = "dress that has a hem much wider than its shoulders", GroupId = 6},
        new Property() {Id = 13, Name = "Beaded shift", Description = "?????", GroupId = 7},
        new Property() {Id = 14, Name = "beaded collar", Description = "????? ??? ??? ??? (?????)", GroupId = 6},
        new Property() {Id = 15, Name = "Bodycon", Description = "Dress that follow the body", GroupId = 6},
        new Property()
            {Id = 16, Name = "Box pleated", Description = "a-line shape and a gently exaggerated sleeve", GroupId = 6},
        new Property() {Id = 17, Name = "Button Up", Description = "Buttoned dress", GroupId = 7},
        new Property()
        {
            Id = 18, Name = "Capri", Description = "close-fitting women's pants that end above the ankle", GroupId = 6
        },
        new Property() {Id = 19, Name = "Cargo", Description = "Dress with many pockets", GroupId = 6},
        new Property() {Id = 20, Name = "Pleated", Description = "???", GroupId = 6},
        new Property() {Id = 21, Name = "Gathered waistline", Description = "Gathered to the waist", GroupId = 8},
        new Property() {Id = 22, Name = "Long", Description = "lengthy  dress", GroupId = 9},
        new Property() {Id = 23, Name = "Midi", Description = "Mid length dress", GroupId = 9},
        new Property()
            {Id = 25, Name = "Shawl collar", Description = "???? ????? ??? ??? ??? ???? ??????", GroupId = 10},
        new Property() {Id = 26, Name = "Short sleeve", Description = "short sleeve top", GroupId = 11},
        new Property() {Id = 27, Name = "Square", Description = "Square shaped neckline", GroupId = 10},
        new Property()
        {
            Id = 28, Name = "Surplice neck", Description = "??? ?????? ???? ???? ??? ???? ????? ? ?????", GroupId = 10
        },
        new Property() {Id = 31, Name = "Turtleneck", Description = "Long neck dress", GroupId = 10},
        new Property() {Id = 32, Name = "Tweed", Description = "short dress", GroupId = 9},
        new Property() {Id = 33, Name = "Bootcut", Description = "Cotton fabric pants loose from ankles", GroupId = 12},
        new Property() {Id = 34, Name = "Boyfriend", Description = "loose jeans or pants (straight fit)", GroupId = 13},
        new Property() {Id = 35, Name = "Crop", Description = "Short jeans", GroupId = 13},
        new Property() {Id = 36, Name = "Crop", Description = "Short fabric pants", GroupId = 12},
        new Property() {Id = 37, Name = "Cuffed Hem", Description = "????? ???? ????? ?? ??????", GroupId = 13},
        new Property() {Id = 38, Name = "Distressed", Description = "pants with holes", GroupId = 13},
        new Property() {Id = 39, Name = "Straight Fit", Description = "wide pants", GroupId = 12},
        new Property() {Id = 40, Name = "Straight Fit", Description = "wide jeans", GroupId = 13},
        new Property() {Id = 41, Name = "Side slit", Description = "A slit from the knees down", GroupId = 14},
        new Property() {Id = 43, Name = "Floral", Description = "Flowers print", GroupId = 15},
        new Property() {Id = 44, Name = "Skinny", Description = "Skin tight pants", GroupId = 12},
        new Property() {Id = 45, Name = "Skinny ", Description = "Skin tight pants", GroupId = 13},
        new Property() {Id = 46, Name = "Lace", Description = "knitting thread in patterns", GroupId = 15},
        new Property() {Id = 47, Name = "Long sleeve", Description = "Long sleeve", GroupId = 16},
        new Property()
        {
            Id = 48, Name = "Peplum", Description = "a short section attached to the waistline of a blouse",
            GroupId = 000
        },
        new Property() {Id = 49, Name = "Plaid", Description = "square pattern", GroupId = 15},
        new Property() {Id = 51, Name = "Raglan sleeve", Description = "????? ?? ????? ???? ???????", GroupId = 16},
        new Property() {Id = 52, Name = "Round neck", Description = "round shaped neckline", GroupId = 17},
        new Property() {Id = 53, Name = "Satin", Description = "Fabric", GroupId = 18},
        new Property() {Id = 54, Name = "asymmetric", Description = "Shoulder style", GroupId = 27},
        new Property()
        {
            Id = 56, Name = "asymmetrical hem", Description = "the bottom half of the garment is cut in an angle",
            GroupId = 19
        },
        new Property()
            {Id = 57, Name = "Batwing", Description = "aslo called butterfly wide more fabric sleeves", GroupId = 20},
        new Property() {Id = 58, Name = "Beaded collar", Description = "beaded on the neckline", GroupId = 21},
        new Property() {Id = 59, Name = "Bell sleeve", Description = "bell shaped sleeve", GroupId = 20},
        new Property() {Id = 60, Name = "Belted", Description = "belt on the waist", GroupId = 22},
        new Property() {Id = 61, Name = "Buttoned", Description = "with buttons", GroupId = 22},
        new Property() {Id = 62, Name = "caged", Description = "laces like stripes", GroupId = 19},
        new Property() {Id = 63, Name = "Check-Patterned", Description = "karo", GroupId = 23},
        new Property() {Id = 64, Name = "Cinched neck", Description = "gathered to the neck", GroupId = 24},
        new Property() {Id = 65, Name = "Cinched waist", Description = "gathered to the waist", GroupId = 24},
        new Property() {Id = 66, Name = "Collared", Description = "collared neck top", GroupId = 21},
        new Property()
            {Id = 67, Name = "Collarless", Description = "with no collar on the neck Eg: open shoulders", GroupId = 21},
        new Property() {Id = 68, Name = "color block pocket", Description = "colored pocket on the top", GroupId = 19},
        new Property() {Id = 69, Name = "Crepe", Description = "light fabric", GroupId = 25},
        new Property() {Id = 70, Name = "Crochet", Description = "knitted with thick wool", GroupId = 25},
        new Property()
            {Id = 71, Name = "Deep V neck", Description = "the point of the V is till the waist line", GroupId = 21},
        new Property()
        {
            Id = 72, Name = "Dolman",
            Description = "???? ???? ???? ??? ???? ????? ???? ??? ????? ?????? ?? ??? ???? ????? ?????", GroupId = 20
        },
        new Property()
            {Id = 73, Name = "Double breasted", Description = "Double buttons on a coat or blazer", GroupId = 19},
        new Property()
            {Id = 74, Name = "drape front", Description = "looks as if the fabric is wrapped ", GroupId = 19},
        new Property() {Id = 75, Name = "Draped", Description = "draped top", GroupId = 19},
        new Property() {Id = 76, Name = "Drawstring", Description = "style as a detail", GroupId = 22},
        new Property()
            {Id = 77, Name = "Drop waist", Description = "drops below the the waistline A shape", GroupId = 6},
        new Property()
        {
            Id = 78, Name = "Fringe", Description = "fine lines/threads of fabric hanging over from the garment ",
            GroupId = 22
        },
        new Property()
            {Id = 79, Name = "Horizontal stripes ", Description = "Horizontal stripes pattern top", GroupId = 23},
        new Property() {Id = 80, Name = "Vertical stripes", Description = "Vertical stripes pattern", GroupId = 23},
        new Property() {Id = 81, Name = "High waist", Description = "High waist ", GroupId = 26},
        new Property()
        {
            Id = 82, Name = "High slit", Description = "the openning of the dress is righ below the waist", GroupId = 26
        },
        new Property()
        {
            Id = 83, Name = "illusion neckline",
            Description = "clear fabric that makes the dress invisible on the shoulders ", GroupId = 21
        },
        new Property() {Id = 84, Name = "knit raglan", Description = "wool knitted top", GroupId = 25},
        new Property() {Id = 85, Name = "notched collar", Description = "type of collar", GroupId = 21},
        new Property() {Id = 86, Name = "open knit", Description = "gapped knitted top", GroupId = 25},
        new Property() {Id = 87, Name = "Pleated", Description = "???", GroupId = 19},
        new Property() {Id = 88, Name = "sheer", Description = "invisible", GroupId = 25},
        new Property() {Id = 89, Name = "Shirred", Description = "Detailed", GroupId = 22},
        new Property() {Id = 90, Name = "Side slit", Description = "a slit from the waist down", GroupId = 19},
        new Property() {Id = 91, Name = "Sleek", Description = "soft dress", GroupId = 6},
        new Property() {Id = 92, Name = "Sleek", Description = "soft ", GroupId = 25},
        new Property() {Id = 93, Name = "Sleeveless", Description = "no sleeves", GroupId = 20},
        new Property()
            {Id = 94, Name = "Slub knit", Description = "??? ????? ?? ???? ???? ??? ????? ?? ????", GroupId = 25},
        new Property() {Id = 95, Name = "Split Back", Description = "opened from the back", GroupId = 4},
        new Property() {Id = 96, Name = "Split neck", Description = "opening in the neck", GroupId = 21},
        new Property() {Id = 97, Name = "Tie front", Description = "details", GroupId = 22},
        new Property() {Id = 98, Name = "Twist front", Description = "wrapped style from the front", GroupId = 19},
        new Property() {Id = 99, Name = "V neck", Description = "V shaped neckline", GroupId = 21},
        new Property() {Id = 100, Name = "Windowpane", Description = "Grid pattern", GroupId = 23},
        new Property() {Id = 101, Name = "Woven", Description = "Tightly knitted top", GroupId = 25},
        new Property() {Id = 102, Name = "Zipper", Description = "a zipper in the top", GroupId = 22},
        new Property() {Id = 103, Name = "Speckled ", Description = "dotted pattern", GroupId = 23},
        new Property() {Id = 104, Name = "Bow front", Description = "front bow tie", GroupId = 22},
        new Property()
            {Id = 105, Name = "Butterfly", Description = "wide from the sleeve like butterfly", GroupId = 19},
        new Property() {Id = 106, Name = "Chiffon", Description = "chiffon fabric", GroupId = 25},
        new Property() {Id = 108, Name = "Draped shawl", Description = "?? ??? ???", GroupId = 22},
        new Property() {Id = 109, Name = "Peasant", Description = "style with a peasant pattern", GroupId = 23},
        new Property() {Id = 110, Name = "Racerback", Description = "sport clothing", GroupId = 4},
        new Property()
            {Id = 111, Name = "southwestern-patterned", Description = "southwestern-patterned", GroupId = 23},
        new Property() {Id = 112, Name = "tartan", Description = "tartan pattern", GroupId = 23},
        new Property() {Id = 113, Name = "Tassel", Description = "decorate with a tassel or tassels.", GroupId = 22},
        new Property()
            {Id = 114, Name = "Tie neck", Description = "a tie with the fabric near the neck ", GroupId = 21},
        new Property() {Id = 115, Name = "Twisted-Hem", Description = "wrapped near the hem line", GroupId = 26},
        new Property() {Id = 116, Name = "boat neck", Description = "U shaped neckline", GroupId = 17},
        new Property() {Id = 117, Name = "cap-sleeve", Description = "? ??? ??? ???? (???)", GroupId = 20},
        new Property() {Id = 118, Name = "M slit", Description = "M shaped slit in a dress ", GroupId = 6},
        new Property()
        {
            Id = 119, Name = "Maxi dress", Description = "long dress that skims the top of the feet or the ankles",
            GroupId = 9
        },
        new Property()
        {
            Id = 120, Name = "Off the shoulder", Description = "no shoulder it has sleeve unlike strapless",
            GroupId = 27
        },
        new Property() {Id = 121, Name = "One shoulder", Description = "one shoulder strapped dress", GroupId = 27},
        new Property() {Id = 122, Name = "Scalloped", Description = "neckline shape", GroupId = 17},
        new Property()
        {
            Id = 123, Name = "Scoop neck",
            Description =
                "scoop neck shirt is one in which the scoop-shape neckline drops significantly below normal limits",
            GroupId = 17
        },
        new Property() {Id = 124, Name = "Strapless", Description = "no straps on the shoulders", GroupId = 27},
        new Property() {Id = 125, Name = "bottom property", Description = "some description", GroupId = 6},
        new Property() {Id = 126, Name = "TestBottom", Description = "some disc", GroupId = 6},
        new Property()
            {Id = 10126, Name = "shoulder strap ", Description = "light strap on the shoulder", GroupId = 28},
        new Property() {Id = 10127, Name = "U neckline", Description = "U shaped neckline", GroupId = 21},
        new Property() {Id = 10128, Name = "Skin tight", Description = "the same size of the body", GroupId = 25},
        new Property() {Id = 10129, Name = "Sporty", Description = "sport clothings", GroupId = 19},
        new Property() {Id = 10130, Name = "Sleeveless", Description = "no sleeves", GroupId = 20},
        new Property() {Id = 10131, Name = "Mesh", Description = "mesh fabric present in the garment", GroupId = 7},
        new Property() {Id = 10132, Name = "High Waist", Description = "High Waist dress", GroupId = 8},
        new Property() {Id = 10133, Name = "Sleeveless", Description = "no sleeves", GroupId = 11},
        new Property() {Id = 10134, Name = "Round neck", Description = "Round neckline", GroupId = 10},
        new Property() {Id = 10135, Name = "Deep V neckline", Description = "Deep V neckline", GroupId = 10},
        new Property() {Id = 10136, Name = "Round neckline", Description = "round neckline", GroupId = 21},
        new Property() {Id = 10137, Name = "assymetrical hem", Description = "assymetrical hem", GroupId = 26},
        new Property() {Id = 10138, Name = "Long sleeves", Description = "long sleeve", GroupId = 20},
        new Property() {Id = 10139, Name = "Draped Dress", Description = "Draped Dress", GroupId = 7},
        new Property() {Id = 10140, Name = "V neck", Description = "V neck", GroupId = 10},
        new Property() {Id = 10141, Name = "Belted", Description = "Belted waist dress", GroupId = 7},
        new Property() {Id = 10142, Name = "Bowtie", Description = "Bowtie ", GroupId = 7},
        new Property() {Id = 10143, Name = "Dolphin hem", Description = "Dolphin hem", GroupId = 2},
        new Property() {Id = 10144, Name = "High Waist", Description = "High Waist", GroupId = 3},
        new Property() {Id = 10145, Name = "side slit", Description = "ss", GroupId = 3},
        new Property() {Id = 10146, Name = "asymmetrical hem", Description = "asymmetrical hem", GroupId = 2},
        new Property() {Id = 10147, Name = "Vented", Description = "holes in the pants", GroupId = 1},
        new Property() {Id = 10148, Name = "flat front", Description = "flat front", GroupId = 3},
        new Property() {Id = 10149, Name = "flounce", Description = "f", GroupId = 3},
        new Property() {Id = 10150, Name = "Collared", Description = "Collared", GroupId = 10},
        new Property() {Id = 10151, Name = "U neckline", Description = "U shaped neckline", GroupId = 10},
        new Property() {Id = 10152, Name = "Turtleneck", Description = "turtleneck ", GroupId = 21},
        new Property() {Id = 10153, Name = "Maxi dress", Description = "Maxi dress", GroupId = 6},
        new Property() {Id = 10154, Name = "Off-Shoulder ", Description = "Off-Shoulder ", GroupId = 28},
        new Property() {Id = 10155, Name = "Off-Shoulder ", Description = "Off-Shoulder ", GroupId = 21},
        new Property() {Id = 10156, Name = "Waist Flounce ", Description = "Flounce", GroupId = 22},
        new Property()
            {Id = 10157, Name = "Asymmetrical hem Dress", Description = "Asymmetrical hem Dress", GroupId = 6},
        new Property() {Id = 10158, Name = "Wide leg", Description = "loose", GroupId = 29},
        new Property() {Id = 10159, Name = "Vertical stripes", Description = "vertical stripes", GroupId = 29},
        new Property() {Id = 10160, Name = "Empire", Description = "Empire", GroupId = 29},
        new Property() {Id = 10161, Name = "wrap", Description = "w", GroupId = 29},
        new Property() {Id = 10162, Name = "pleated flare", Description = "ee", GroupId = 29},
        new Property() {Id = 10163, Name = "straight leg", Description = "s", GroupId = 29},
        new Property() {Id = 10164, Name = "belted", Description = "s", GroupId = 30},
        new Property() {Id = 10165, Name = "ruffle", Description = "s", GroupId = 30},
        new Property() {Id = 10166, Name = "drawstring", Description = "s", GroupId = 30},
        new Property() {Id = 10167, Name = "peplum", Description = "s", GroupId = 30},
        new Property() {Id = 10168, Name = "Strapless", Description = "a", GroupId = 29},
        new Property() {Id = 10169, Name = "asymmetric", Description = "a", GroupId = 29},
        new Property() {Id = 10170, Name = "Culottes", Description = "z", GroupId = 29},
        new Property() {Id = 10171, Name = "Two colors", Description = "s", GroupId = 29},
        new Property() {Id = 10172, Name = "Deep V neck", Description = "s", GroupId = 29},
        new Property() {Id = 10173, Name = "Flared leg", Description = "s", GroupId = 29},
        new Property()
            {Id = 10174, Name = "pattern peasant two colors", Description = "pattern peasant two colors", GroupId = 12},
        new Property() {Id = 10175, Name = "Wide leg", Description = "loose", GroupId = 12},
        new Property() {Id = 10176, Name = "High Waist", Description = "s", GroupId = 31},
        new Property() {Id = 10177, Name = "low waist", Description = "a", GroupId = 31},
        new Property() {Id = 10178, Name = "tulip", Description = "skirt property", GroupId = 3},
        new Property() {Id = 10179, Name = "Box pleated", Description = "skirt property", GroupId = 3},
        new Property() {Id = 10180, Name = "A line", Description = "skirt property", GroupId = 3},
        new Property() {Id = 10181, Name = "Bias ", Description = "skirt property", GroupId = 3},
        new Property() {Id = 10182, Name = "Layered", Description = "skirt property", GroupId = 3},
        new Property() {Id = 10183, Name = "flip", Description = "skirt property", GroupId = 3},
        new Property() {Id = 10184, Name = "full", Description = "skirt property", GroupId = 3},
        new Property() {Id = 10185, Name = "panelled", Description = "skirt property", GroupId = 3},
        new Property() {Id = 10186, Name = "bubble", Description = "skirt property", GroupId = 3},
        new Property() {Id = 10187, Name = "pencil", Description = "skirt property", GroupId = 3}
    };


    public static List<Garment> garments = new List<Garment>()
    {
        new Garment()
        {
            Id = 1, Name = "A line Dress", Description = "A line Dress", Brand = "Lazorde", Price = new decimal(66.5),
            CategoryId = 2, StoreId = 1
        },
        new Garment()
        {
            Id = 2, Name = "Athletic Tank", Description = "Sports Tank top", Brand = "adidas", Price = new decimal(5),
            CategoryId = 5, StoreId = 2
        },
        new Garment()
        {
            Id = 4, Name = "Athletic Tank", Description = "sport clothing", Brand = "adidas", Price = new decimal(7),
            CategoryId = 5, StoreId = 1
        },
        new Garment()
        {
            Id = 5, Name = "Mesh Pleated Jersey Dress", Description = "Mesh Pleated Jersey Dress", Brand = "Coala",
            Price = new decimal(19), CategoryId = 2, StoreId = 2
        },
        new Garment()
        {
            Id = 6, Name = "Midi Bodycon dress", Description = "Midi Bodycon dress", Brand = "Havana",
            Price = new decimal(5), CategoryId = 2, StoreId = 2
        },
        new Garment()
        {
            Id = 7, Name = "Mesh Pleated Jersey Dress", Description = "Mesh Pleated Jersey Dress", Brand = "Coala",
            Price = new decimal(43), CategoryId = 2, StoreId = 2
        },
        new Garment()
        {
            Id = 8, Name = "Capri styled dress", Description = "Capri styled dress", Brand = "Mangos",
            Price = new decimal(9.99), CategoryId = 2, StoreId = 1
        },
        new Garment()
        {
            Id = 9, Name = "assymetrical hem shirt", Description = "assymetrical hem shirt", Brand = "Mangos",
            Price = new decimal(5), CategoryId = 5, StoreId = 2
        },
        new Garment()
        {
            Id = 10, Name = "asymmetrical hem Top", Description = "asymmetrical hem Top", Brand = "Coala",
            Price = new decimal(3), CategoryId = 5, StoreId = 2
        },
        new Garment()
        {
            Id = 11, Name = "asymmetrical hem Shirt", Description = "asymmetrical hem Shirt", Brand = "Havana",
            Price = new decimal(0), CategoryId = 5, StoreId = 1
        },
        new Garment()
        {
            Id = 12, Name = "asymmetrical hem long shirt", Description = "asymmetrical hem Top", Brand = "Berchika",
            Price = new decimal(7), CategoryId = 5, StoreId = 2
        },
        new Garment()
        {
            Id = 13, Name = "asymmetrical hem Top", Description = "Chiffon shirt", Brand = "Coala",
            Price = new decimal(0), CategoryId = 5, StoreId = 2
        },
        new Garment()
        {
            Id = 14, Name = "asymmetrical hem Top", Description = "asymmetrical hem shoulder straps", Brand = "Havana",
            Price = new decimal(5), CategoryId = 5, StoreId = 2
        },
        new Garment()
        {
            Id = 15, Name = "asymmetrical hem Top", Description = "asymmetrical hem Top", Brand = "Mangos",
            Price = new decimal(5), CategoryId = 5, StoreId = 2
        },
        new Garment()
        {
            Id = 16, Name = "asymmetrical hem Top", Description = "asymmetrical hem Top", Brand = "Lazorde",
            Price = new decimal(2), CategoryId = 5, StoreId = 2
        },
        new Garment()
        {
            Id = 17, Name = "asymmetrical hem Top", Description = "asymmetrical hem Top", Brand = "Havana",
            Price = new decimal(0), CategoryId = 5, StoreId = 1
        },
        new Garment()
        {
            Id = 18, Name = "Bodycon Dress", Description = "Bodycon Dress", Brand = "Berchika",
            Price = new decimal(9.99), CategoryId = 2, StoreId = 1
        },
        new Garment()
        {
            Id = 19, Name = "Bodycon Dress", Description = "Bodycon Dress", Brand = "Mangos", Price = new decimal(9.99),
            CategoryId = 2, StoreId = 2
        },
        new Garment()
        {
            Id = 20, Name = "Bodycon Dress", Description = "Bodycon with flared waist dress", Brand = "Coala",
            Price = new decimal(4.99), CategoryId = 2, StoreId = 2
        },
        new Garment()
        {
            Id = 21, Name = "Vertical camuflage ", Description = "Vertical camuflage ", Brand = "CarkoQ",
            Price = new decimal(9.99), CategoryId = 5, StoreId = 2
        },
        new Garment()
        {
            Id = 22, Name = "Chiffon sleeves ", Description = "Chiffon sleeves ", Brand = "Mangos",
            Price = new decimal(9.99), CategoryId = 5, StoreId = 1
        },
        new Garment()
        {
            Id = 23, Name = "Belted waist dress", Description = "Belted waist dress", Brand = "Mangos",
            Price = new decimal(9.99), CategoryId = 2, StoreId = 1
        },
        new Garment()
        {
            Id = 24, Name = "Belted Dress", Description = "Belted Dress", Brand = "Mangos", Price = new decimal(9.99),
            CategoryId = 2, StoreId = 2
        },
        new Garment()
        {
            Id = 25, Name = "Belted waist dress", Description = "Belted waist dress", Brand = "Chivara",
            Price = new decimal(4.99), CategoryId = 2, StoreId = 2
        },
        new Garment()
        {
            Id = 26, Name = "Brush Stroke", Description = "Brush Stroke", Brand = "Berchika", Price = new decimal(9.99),
            CategoryId = 5, StoreId = 1
        },
        new Garment()
        {
            Id = 27, Name = "Button Up ", Description = "Button Up ", Brand = "Chivara", Price = new decimal(4),
            CategoryId = 5, StoreId = 1
        },
        new Garment()
        {
            Id = 28, Name = "Buttoned with bowtie", Description = "Buttoned with bowtie", Brand = "Havana",
            Price = new decimal(3), CategoryId = 5, StoreId = 1
        },
        new Garment()
        {
            Id = 29, Name = "Button Up with cinched waist", Description = "Button Up with cinched waist",
            Brand = "Coala", Price = new decimal(9.99), CategoryId = 5, StoreId = 1
        },
        new Garment()
        {
            Id = 30, Name = "Draped Dress ", Description = "Draped Dress ", Brand = "Havana", Price = new decimal(4.99),
            CategoryId = 2, StoreId = 2
        },
        new Garment()
        {
            Id = 31, Name = "Gathered waistline Dress", Description = "Gathered waistline Dress", Brand = "Mangos",
            Price = new decimal(9), CategoryId = 2, StoreId = 2
        },
        new Garment()
        {
            Id = 32, Name = "Gathered waistline Dress", Description = "Gathered waistline Dress",
            Brand = "Sawsan Sweing ", Price = new decimal(4), CategoryId = 2, StoreId = 1
        },
        new Garment()
        {
            Id = 33, Name = "Gathered waistline Dress", Description = "Gathered waistline Dress with bowtie",
            Brand = "Sawsan Sweing ", Price = new decimal(3), CategoryId = 2, StoreId = 1
        },
        new Garment()
        {
            Id = 34, Name = "Crochet knitted ", Description = "Crochet knitted ", Brand = "Coala",
            Price = new decimal(0), CategoryId = 5, StoreId = 1
        },
        new Garment()
        {
            Id = 35, Name = "Short Bootcut pants", Description = "Short Bootcut pants", Brand = "Centerpoint ",
            Price = new decimal(5), CategoryId = 4, StoreId = 1
        },
        new Garment()
        {
            Id = 36, Name = "Crop pants", Description = "Crop pants", Brand = "Mangos", Price = new decimal(2),
            CategoryId = 4, StoreId = 1
        },
        new Garment()
        {
            Id = 37, Name = "Bootcut", Description = "bootcut", Brand = "Coala", Price = new decimal(5), CategoryId = 4,
            StoreId = 1
        },
        new Garment()
        {
            Id = 38, Name = "Diamond pattern dress", Description = "Diamond pattern drop waist dress", Brand = "Mangos",
            Price = new decimal(2), CategoryId = 2, StoreId = 1
        },
        new Garment()
        {
            Id = 39, Name = "Drop waist dress", Description = "Drop waist dress", Brand = "Mangos",
            Price = new decimal(9.99), CategoryId = 2, StoreId = 1
        },
        new Garment()
        {
            Id = 40, Name = "Drop waist dress", Description = "Drop waist dress", Brand = "Coala",
            Price = new decimal(0), CategoryId = 2, StoreId = 1
        },
        new Garment()
        {
            Id = 41, Name = "Drop waist dress", Description = "Drop waist dress", Brand = "Havana",
            Price = new decimal(9.99), CategoryId = 2, StoreId = 1
        },
        new Garment()
        {
            Id = 42, Name = "Drop waist dress", Description = "Drop waist dress", Brand = "Lazorde",
            Price = new decimal(0), CategoryId = 2, StoreId = 2
        },
        new Garment()
        {
            Id = 43, Name = "Bodycon Dress", Description = "Bodycon Dress", Brand = "Lazorde", Price = new decimal(0),
            CategoryId = 2, StoreId = 1
        },
        new Garment()
        {
            Id = 44, Name = "Bodycon Dress", Description = "Bodycon Dress", Brand = "Lazorde", Price = new decimal(0),
            CategoryId = 2, StoreId = 2
        },
        new Garment()
        {
            Id = 45, Name = "chiffon speckled top", Description = "chiffon speckled top", Brand = "Lora",
            Price = new decimal(7), CategoryId = 5, StoreId = 2
        },
        new Garment()
        {
            Id = 46, Name = "Front Draped top", Description = "front Draped top", Brand = "Berchika",
            Price = new decimal(1.5), CategoryId = 5, StoreId = 2
        },
        new Garment()
        {
            Id = 47, Name = "Front Draped top", Description = "Front Draped top", Brand = "Mangos",
            Price = new decimal(0), CategoryId = 5, StoreId = 1
        },
        new Garment()
        {
            Id = 48, Name = "Front Draped top", Description = "Front Draped top", Brand = "Coala",
            Price = new decimal(9.99), CategoryId = 5, StoreId = 1
        },
        new Garment()
        {
            Id = 49, Name = "Front bowtie top", Description = "Front bowtie top", Brand = "Coala",
            Price = new decimal(9), CategoryId = 5, StoreId = 1
        },
        new Garment()
        {
            Id = 50, Name = "Drop waist dress", Description = "Drop waist dress", Brand = "Coala",
            Price = new decimal(9.99), CategoryId = 2, StoreId = 1
        },
        new Garment()
        {
            Id = 51, Name = "Asymmetrical hem Dress", Description = "Asymmetrical hem Dress", Brand = "Mangos",
            Price = new decimal(5), CategoryId = 2, StoreId = 1
        },
        new Garment()
        {
            Id = 52, Name = "Mesh Pleated Jersey Dress", Description = "Mesh Pleated Jersey Dress", Brand = "Havana",
            Price = new decimal(53), CategoryId = 2, StoreId = 1
        },
        new Garment()
        {
            Id = 53, Name = "Front Draped Drop waist dress", Description = "Front Draped Drop waist dress",
            Brand = "Lazorde", Price = new decimal(7), CategoryId = 2, StoreId = 1
        },
        new Garment()
        {
            Id = 54, Name = "Chiffon speckled top", Description = "chiffon speckled top", Brand = "Berchika",
            Price = new decimal(5), CategoryId = 5, StoreId = 2
        },
        new Garment()
        {
            Id = 55, Name = "A line dress", Description = "A line dress", Brand = "Mangos", Price = new decimal(4),
            CategoryId = 2, StoreId = 2
        },
        new Garment()
        {
            Id = 56, Name = "Long Drop waist", Description = "Long Drop waist", Brand = "Mangos",
            Price = new decimal(3), CategoryId = 2, StoreId = 2
        },
        new Garment()
        {
            Id = 57, Name = "Drop waist dress", Description = "Drop waist dress", Brand = "Coala",
            Price = new decimal(3), CategoryId = 2, StoreId = 1
        },
        new Garment()
        {
            Id = 58, Name = "Chiffon speckled top", Description = "Chiffon speckled top", Brand = "Lazorde",
            Price = new decimal(9.99), CategoryId = 5, StoreId = 2
        },
        new Garment()
        {
            Id = 59, Name = "Turtleneck knit raglan", Description = "Turtleneck knit raglan", Brand = "Havana",
            Price = new decimal(0), CategoryId = 5, StoreId = 1
        },
        new Garment()
        {
            Id = 60, Name = "Maxi dress", Description = "Maxi dress", Brand = "Mangos", Price = new decimal(6),
            CategoryId = 2, StoreId = 2
        },
        new Garment()
        {
            Id = 61, Name = "Maxi dress", Description = "Maxi dress", Brand = "Mangos", Price = new decimal(7),
            CategoryId = 2, StoreId = 2
        },
        new Garment()
        {
            Id = 62, Name = "Off-Shoulder ", Description = "Off-Shoulder ", Brand = "Berchika", Price = new decimal(2),
            CategoryId = 5, StoreId = 2
        },
        new Garment()
        {
            Id = 63, Name = "Off-Shoulder ", Description = "Off-Shoulder ", Brand = "Havana", Price = new decimal(9.99),
            CategoryId = 5, StoreId = 1
        },
        new Garment()
        {
            Id = 64, Name = "Off-Shoulder waist flounce", Description = "Off-Shoulder waist flounce", Brand = "Havana",
            Price = new decimal(9.99), CategoryId = 5, StoreId = 2
        },
        new Garment()
        {
            Id = 65, Name = "Off-Shoulder Bust flounce", Description = "Off-Shoulder Bust flounce", Brand = "Coala",
            Price = new decimal(3), CategoryId = 5, StoreId = 2
        },
        new Garment()
        {
            Id = 66, Name = "Two buttons Off-Shoulder ", Description = "Two buttons Off-Shoulder ", Brand = "Lazorde",
            Price = new decimal(4), CategoryId = 5, StoreId = 1
        },
        new Garment()
        {
            Id = 67, Name = "A line dress", Description = "A line dress", Brand = "Coala", Price = new decimal(6),
            CategoryId = 2, StoreId = 2
        },
        new Garment()
        {
            Id = 68, Name = "Asymmetrical hem Dress", Description = "Asymmetrical hem Dress", Brand = "Havana",
            Price = new decimal(9.99), CategoryId = 2, StoreId = 1
        },
        new Garment()
        {
            Id = 69, Name = "Batwing ", Description = "Batwing ", Brand = "Mangos", Price = new decimal(4.99),
            CategoryId = 5, StoreId = 1
        },
        new Garment()
        {
            Id = 70, Name = "southwestern-patterned jumbsuit",
            Description = "southwestern-patterned jumbsuit with Wide legs", Brand = "Mangos", Price = new decimal(10),
            CategoryId = 7, StoreId = 1
        },
        new Garment()
        {
            Id = 71, Name = "Bright Textured jumbsuit", Description = "Bright Textured jumbsuit with waist belt",
            Brand = "Havana", Price = new decimal(2), CategoryId = 7, StoreId = 1
        },
        new Garment()
        {
            Id = 74, Name = "reddish jumbsuit", Description = "reddish jumbsuit with wide legs and belted",
            Brand = "Havana", Price = new decimal(7.99), CategoryId = 7, StoreId = 2
        },
        new Garment()
        {
            Id = 75, Name = "Jumbsuit ", Description = "strapless wide legged Jumbsuit ", Brand = "Berchika",
            Price = new decimal(6), CategoryId = 7, StoreId = 2
        },
        new Garment()
        {
            Id = 76, Name = "JumbSuit ", Description = "jumbsuit with waist detail and straps", Brand = "Lazorde",
            Price = new decimal(3), CategoryId = 7, StoreId = 2
        },
        new Garment()
        {
            Id = 77, Name = "Jubmbsuit", Description = "jumbsuit with waist belt detail and straps", Brand = "Coala",
            Price = new decimal(9.99), CategoryId = 7, StoreId = 2
        },
        new Garment()
        {
            Id = 78, Name = "Jubmbsuit", Description = "strapless jumbsuit with waist detail ", Brand = "Havana",
            Price = new decimal(6), CategoryId = 7, StoreId = 1
        },
        new Garment()
        {
            Id = 79, Name = "Jubmbsuit", Description = "jumbsuit with chinched waist and wide straps",
            Brand = "Lazorde", Price = new decimal(2), CategoryId = 7, StoreId = 1
        },
        new Garment()
        {
            Id = 82, Name = "Jubmbsuit", Description = "jumbsuit with chinched waist and straps", Brand = "Lazorde",
            Price = new decimal(4), CategoryId = 7, StoreId = 2
        },
        new Garment()
        {
            Id = 83, Name = "Jubmbsuit", Description = "strapless jumbsuit with high waist ", Brand = "Coala",
            Price = new decimal(3), CategoryId = 7, StoreId = 1
        },
        new Garment()
        {
            Id = 84, Name = "peplum jumbsuit", Description = "jumbsuit with peplum on bust and pockets",
            Brand = "Havana", Price = new decimal(9.99), CategoryId = 7, StoreId = 1
        },
        new Garment()
        {
            Id = 85, Name = "Culottes jumbsuit", Description = "Culottes style jumbsuit with back bow",
            Brand = "Havana", Price = new decimal(4), CategoryId = 7, StoreId = 1
        },
        new Garment()
        {
            Id = 86, Name = "Jubmbsuit", Description = "jumbsuit with chinched waist and straps", Brand = "Mangos",
            Price = new decimal(3), CategoryId = 7, StoreId = 1
        },
        new Garment()
        {
            Id = 87, Name = "Jubmbsuit", Description = "front bow tie jumbsuit with flared legs", Brand = "Havana",
            Price = new decimal(4), CategoryId = 7, StoreId = 1
        },
        new Garment()
        {
            Id = 89, Name = "Jubmbsuit", Description = "jumbsuit with pockets ", Brand = "Lazorde",
            Price = new decimal(3), CategoryId = 7, StoreId = 1
        },
        new Garment()
        {
            Id = 90, Name = "Dolman sleeve top", Description = "Dolman sleeve top     ", Brand = "Havana",
            Price = new decimal(0), CategoryId = 5, StoreId = 1
        },
        new Garment()
        {
            Id = 91, Name = "patterned joggers", Description = "patterned joggers with drawstring", Brand = "Havana",
            Price = new decimal(5), CategoryId = 4, StoreId = 1
        },
        new Garment()
        {
            Id = 92, Name = "patterned joggers", Description = "patterned joggers", Brand = "Havana",
            Price = new decimal(9.99), CategoryId = 4, StoreId = 2
        },
        new Garment()
        {
            Id = 93, Name = "drawstring joggers", Description = "high waist drawstring joggers", Brand = "Lazorde",
            Price = new decimal(0), CategoryId = 4, StoreId = 1
        },
        new Garment()
        {
            Id = 94, Name = "drawstring joggers", Description = "drawstring joggers", Brand = "Coala",
            Price = new decimal(0), CategoryId = 4, StoreId = 1
        },
        new Garment()
        {
            Id = 95, Name = "drawstring joggers", Description = "drawstring joggers", Brand = "Mangos",
            Price = new decimal(0), CategoryId = 4, StoreId = 1
        },
        new Garment()
        {
            Id = 96, Name = "drawstring joggers", Description = "drawstring joggers", Brand = "Havana",
            Price = new decimal(5), CategoryId = 4, StoreId = 1
        },
        new Garment()
        {
            Id = 97, Name = "Print skirt", Description = "Print skirt", Brand = "Lookas", Price = new decimal(22),
            CategoryId = 1, StoreId = 2
        },
        new Garment()
        {
            Id = 98, Name = "Panelled skirt ", Description = "Panelled skirt ", Brand = "Lazorde",
            Price = new decimal(40), CategoryId = 1, StoreId = 2
        },
        new Garment()
        {
            Id = 99, Name = "Tall skirt", Description = "Tall skirt", Brand = "Havana", Price = new decimal(2),
            CategoryId = 1, StoreId = 2
        },
        new Garment()
        {
            Id = 100, Name = "Full skirt", Description = "Full skirt", Brand = "Havana", Price = new decimal(3),
            CategoryId = 1, StoreId = 2
        },
        new Garment()
        {
            Id = 101, Name = "wrap end skirt", Description = "wrap end skirt", Brand = "Havana", Price = new decimal(7),
            CategoryId = 1, StoreId = 1
        },
        new Garment()
        {
            Id = 102, Name = "full skirt", Description = "full skirt", Brand = "Coala", Price = new decimal(2),
            CategoryId = 1, StoreId = 2
        },
        new Garment()
        {
            Id = 103, Name = "pencil style skirt", Description = "pencil style skirt", Brand = "Havana",
            Price = new decimal(3), CategoryId = 1, StoreId = 2
        },
        new Garment()
        {
            Id = 104, Name = "full skirt", Description = "Full skirt", Brand = "Mangos", Price = new decimal(1),
            CategoryId = 1, StoreId = 1
        },
        new Garment()
        {
            Id = 105, Name = "pencil style skirt", Description = "grey pencil style skirt", Brand = "Lazorde",
            Price = new decimal(3), CategoryId = 1, StoreId = 2
        },
        new Garment()
        {
            Id = 106, Name = "Panelled skirt", Description = "Panelled skirt", Brand = "Lookas",
            Price = new decimal(42), CategoryId = 1, StoreId = 1
        },
        new Garment()
        {
            Id = 109, Name = "A Line skirt", Description = "A Line skirt with chiffon ", Brand = "Berchika",
            Price = new decimal(3), CategoryId = 1, StoreId = 2
        },
        new Garment()
        {
            Id = 110, Name = "pencil style skirt", Description = "pencil style skirt", Brand = "Havana",
            Price = new decimal(3), CategoryId = 1, StoreId = 2
        },
        new Garment()
        {
            Id = 111, Name = "Full skirt", Description = "Full skirt", Brand = "Berchika", Price = new decimal(2),
            CategoryId = 1, StoreId = 1
        },
        new Garment()
        {
            Id = 112, Name = "pencil style skirt", Description = "pencil style skirt", Brand = "Mangos",
            Price = new decimal(2), CategoryId = 1, StoreId = 1
        },
        new Garment()
        {
            Id = 113, Name = "Light jeans", Description = "Distressed jeans", Brand = "Denims", Price = new decimal(2),
            CategoryId = 4, StoreId = 1
        },
        new Garment()
        {
            Id = 114, Name = "High Waist jeans", Description = "High Waist straight fit jeans", Brand = "Denims",
            Price = new decimal(2), CategoryId = 4, StoreId = 2
        },
        new Garment()
        {
            Id = 115, Name = "Light jeans", Description = "Distressed jeans", Brand = "Denims", Price = new decimal(2),
            CategoryId = 4, StoreId = 1
        },
        new Garment()
        {
            Id = 116, Name = "Dark blue jeans", Description = "Dark blue jeans", Brand = "Denims",
            Price = new decimal(3), CategoryId = 4, StoreId = 2
        },
        new Garment()
        {
            Id = 117, Name = "High Waist jeans", Description = "blended blue jeans", Brand = "Denims",
            Price = new decimal(2), CategoryId = 4, StoreId = 1
        },
        new Garment()
        {
            Id = 118, Name = "Light jeans", Description = "Light jeans", Brand = "Denims", Price = new decimal(2),
            CategoryId = 4, StoreId = 1
        },
        new Garment()
        {
            Id = 119, Name = "Light jeans", Description = "High waist skinny jeans", Brand = "Denims",
            Price = new decimal(3), CategoryId = 4, StoreId = 1
        },
        new Garment()
        {
            Id = 120, Name = "Light jeans", Description = "Low waist distressed jeans", Brand = "Denims",
            Price = new decimal(3), CategoryId = 4, StoreId = 2
        },
        new Garment()
        {
            Id = 121, Name = "blended grey black jeans",
            Description = "blended grey black jeans with cuffed hem and low waist", Brand = "Denims",
            Price = new decimal(7.99), CategoryId = 4, StoreId = 2
        },
        new Garment()
        {
            Id = 122, Name = "Boyfriend jeans", Description = "Boyfriend jeans ", Brand = "Denims",
            Price = new decimal(3), CategoryId = 4, StoreId = 1
        },
        new Garment()
        {
            Id = 123, Name = "Cuffed Hem", Description = "Dark blue jeans with cuffed hem", Brand = "Denims",
            Price = new decimal(2), CategoryId = 4, StoreId = 1
        },
        new Garment()
        {
            Id = 124, Name = "Skinny jeans", Description = "light blue Skinny jeans", Brand = "Denims",
            Price = new decimal(4), CategoryId = 4, StoreId = 2
        },
        new Garment()
        {
            Id = 125, Name = "Distressed jeans", Description = "Distressed jeans", Brand = "Denims",
            Price = new decimal(4), CategoryId = 4, StoreId = 2
        },
        new Garment()
        {
            Id = 126, Name = "Distressed jeans", Description = "Distressed light jeans", Brand = "Denims",
            Price = new decimal(3), CategoryId = 4, StoreId = 2
        },
        new Garment()
        {
            Id = 127, Name = "Boyfriend jeans", Description = "Boyfriend jeans", Brand = "Denims",
            Price = new decimal(4.99), CategoryId = 4, StoreId = 2
        },
        new Garment()
        {
            Id = 128, Name = "Distressed jeans", Description = "Distressed light jeans", Brand = "Mangos",
            Price = new decimal(2), CategoryId = 4, StoreId = 2
        },
        new Garment()
        {
            Id = 129, Name = "Distressed jeans", Description = "Distressed light jeans WITH cuffed hems",
            Brand = "Denims", Price = new decimal(3), CategoryId = 4, StoreId = 2
        },
        new Garment()
        {
            Id = 130, Name = "Boyfriend jeans", Description = "Boyfriend jeans", Brand = "Denims",
            Price = new decimal(9.99), CategoryId = 4, StoreId = 1
        },
        new Garment()
        {
            Id = 131, Name = "Distressed jeans", Description = "Distressed jeans with cuffed hems", Brand = "Denims",
            Price = new decimal(3), CategoryId = 4, StoreId = 2
        },
        new Garment()
        {
            Id = 132, Name = "Boyfriend jeans", Description = "MOM JEANS", Brand = "Denims", Price = new decimal(2),
            CategoryId = 4, StoreId = 2
        },
        new Garment()
        {
            Id = 133, Name = "Slacks ", Description = "chinched ends slacks", Brand = "Mangos", Price = new decimal(7),
            CategoryId = 4, StoreId = 1
        },
        new Garment()
        {
            Id = 134, Name = "A Line Jeans skirt", Description = "A Line Jeans skirt from denim", Brand = "Denims",
            Price = new decimal(9.99), CategoryId = 1, StoreId = 2
        },
        new Garment()
        {
            Id = 135, Name = "pencil style jeans skirt ", Description = "pencil style jeans skirt from denim",
            Brand = "Denims", Price = new decimal(9.99), CategoryId = 1, StoreId = 2
        },
        new Garment()
        {
            Id = 136, Name = "Acid wash jeans", Description = "Acid wash jeans", Brand = "Denims",
            Price = new decimal(9.99), CategoryId = 4, StoreId = 2
        },
        new Garment()
        {
            Id = 137, Name = "Skinny jeans", Description = "Skinny jeans", Brand = "Denims", Price = new decimal(0),
            CategoryId = 4, StoreId = 1
        },
        new Garment()
        {
            Id = 138, Name = "Full skirt", Description = "White Full skirt", Brand = "Berchika",
            Price = new decimal(10), CategoryId = 1, StoreId = 1
        },
        new Garment()
        {
            Id = 139, Name = "Full skirt", Description = "Golden full skirt", Brand = "Sawsan Sweing ",
            Price = new decimal(9.99), CategoryId = 1, StoreId = 1
        },
        new Garment()
        {
            Id = 140, Name = "M slit Dress", Description = "M slit Dress", Brand = "Havana", Price = new decimal(7),
            CategoryId = 2, StoreId = 1
        },
        new Garment()
        {
            Id = 141, Name = "Dark skinny jeans", Description = "Dark skinny jeans", Brand = "Denims",
            Price = new decimal(9.99), CategoryId = 4, StoreId = 1
        },
    };


    public static List<Image> images = new List<Image>()
    {
        new Image() {Id = 1, Path = "A Line Dress.png", GarmentId = 1},
        new Image() {Id = 2, Path = "img_00000002.jpg", GarmentId = 2},
        new Image() {Id = 3, Path = "cagedBack.jpg", GarmentId = 4},
        new Image() {Id = 4, Path = "img_00000030.jpg", GarmentId = 5},
        new Image() {Id = 5, Path = "img_00000033.jpg", GarmentId = 6},
        new Image() {Id = 6, Path = "img_00000036.jpg", GarmentId = 7},
        new Image() {Id = 7, Path = "img_00000037.jpg", GarmentId = 8},
        new Image() {Id = 8, Path = "img_00000004.jpg", GarmentId = 9},
        new Image() {Id = 9, Path = "img_00000049.jpg", GarmentId = 10},
        new Image() {Id = 10, Path = "img_00000046.jpg", GarmentId = 11},
        new Image() {Id = 11, Path = "img_00000021.jpg", GarmentId = 12},
        new Image() {Id = 12, Path = "Chiffon.jpg", GarmentId = 13},
        new Image() {Id = 13, Path = "img_00000014.jpg", GarmentId = 14},
        new Image() {Id = 14, Path = "img_00000013.jpg", GarmentId = 15},
        new Image() {Id = 15, Path = "VerticalStripes.jpg", GarmentId = 16},
        new Image() {Id = 16, Path = "img_00000005.jpg", GarmentId = 17},
        new Image() {Id = 17, Path = "Bodycon.jpg", GarmentId = 18},
        new Image() {Id = 18, Path = "img_00000006.jpg", GarmentId = 19},
        new Image() {Id = 19, Path = "img_00000019.jpg", GarmentId = 20},
        new Image() {Id = 20, Path = "img_00000001.jpg", GarmentId = 21},
        new Image() {Id = 21, Path = "img_00000007.jpg", GarmentId = 22},
        new Image() {Id = 22, Path = "Belted.jpg", GarmentId = 23},
        new Image() {Id = 23, Path = "belted2.jpg", GarmentId = 24},
        new Image() {Id = 24, Path = "Belted4.jpg", GarmentId = 25},
        new Image() {Id = 25, Path = "BrushStroke.jpg", GarmentId = 26},
        new Image() {Id = 26, Path = "Buttoned.jpg", GarmentId = 27},
        new Image() {Id = 27, Path = "Buttoned2.jpg", GarmentId = 28},
        new Image() {Id = 28, Path = "buttoned3.jpg", GarmentId = 29},
        new Image() {Id = 29, Path = "draped.jpg", GarmentId = 30},
        new Image() {Id = 30, Path = "gatheredwaist2.jpg", GarmentId = 31},
        new Image() {Id = 31, Path = "gatheredwaist5.jpg", GarmentId = 32},
        new Image() {Id = 32, Path = "Gatheredwasit.jpg", GarmentId = 33},
        new Image() {Id = 33, Path = "Sew1.jpg", GarmentId = 34},
        new Image() {Id = 34, Path = "Bootcut.jpg", GarmentId = 35},
        new Image() {Id = 35, Path = "bootcut2.jpg", GarmentId = 36},
        new Image() {Id = 36, Path = "bootcut3.jpg", GarmentId = 37},
        new Image() {Id = 37, Path = "ALine.jpg", GarmentId = 38},
        new Image() {Id = 38, Path = "ALine22.jpg", GarmentId = 39},
        new Image() {Id = 39, Path = "ALINE123.jpg", GarmentId = 40},
        new Image() {Id = 40, Path = "Aline222.jpg", GarmentId = 41},
        new Image() {Id = 41, Path = "ALine333.jpg", GarmentId = 42},
        new Image() {Id = 42, Path = "asa.jpg", GarmentId = 43},
        new Image() {Id = 43, Path = "BODYCON123.jpg", GarmentId = 44},
        new Image() {Id = 44, Path = "cutSleeve.jpg", GarmentId = 45},
        new Image() {Id = 45, Path = "draped4.jpg", GarmentId = 46},
        new Image() {Id = 46, Path = "draped10.jpg", GarmentId = 47},
        new Image() {Id = 47, Path = "draped12.jpg", GarmentId = 48},
        new Image() {Id = 48, Path = "draped22.jpg", GarmentId = 49},
        new Image() {Id = 49, Path = "DropWaist.jpg", GarmentId = 50},
        new Image() {Id = 50, Path = "dropwaist4.jpg", GarmentId = 51},
        new Image() {Id = 51, Path = "DrtopWaist2.jpg", GarmentId = 52},
        new Image() {Id = 52, Path = "few.jpg", GarmentId = 53},
        new Image() {Id = 53, Path = "gatheredwaist99.jpg", GarmentId = 54},
        new Image() {Id = 54, Path = "i9.jpg", GarmentId = 55},
        new Image() {Id = 55, Path = "img_006.jpg", GarmentId = 56},
        new Image() {Id = 56, Path = "img_00000010.jpg", GarmentId = 57},
        new Image() {Id = 57, Path = "img_00000064.jpg", GarmentId = 58},
        new Image() {Id = 58, Path = "knit2.jpg", GarmentId = 59},
        new Image() {Id = 59, Path = "Maxi1.jpg", GarmentId = 60},
        new Image() {Id = 60, Path = "maxi44.jpg", GarmentId = 61},
        new Image() {Id = 61, Path = "OffShoulder1.jpg", GarmentId = 62},
        new Image() {Id = 62, Path = "OffShoulder2.jpg", GarmentId = 63},
        new Image() {Id = 63, Path = "OffShoulder4.jpg", GarmentId = 64},
        new Image() {Id = 64, Path = "offshoulder5.jpg", GarmentId = 65},
        new Image() {Id = 65, Path = "offshoulder6.jpg", GarmentId = 66},
        new Image() {Id = 66, Path = "we.jpg", GarmentId = 67},
        new Image() {Id = 67, Path = "img_00000999.jpg", GarmentId = 68},
        new Image() {Id = 68, Path = "2UOND3KI8Jimg_00000009.jpg", GarmentId = 69},
        new Image() {Id = 69, Path = "OPXCIR6WVHimg_00000001.jpg", GarmentId = 70},
        new Image() {Id = 70, Path = "GOFDCR7UTDimg_00000002.jpg", GarmentId = 71},
        new Image() {Id = 71, Path = "2BZVU3C25Mimg_00000004.jpg", GarmentId = 74},
        new Image() {Id = 72, Path = "BOV5E028DUimg_00000005.jpg", GarmentId = 75},
        new Image() {Id = 73, Path = "MCM8JBOETXimg_00000007.jpg", GarmentId = 76},
        new Image() {Id = 74, Path = "577INJKVGEimg_00000009.jpg", GarmentId = 77},
        new Image() {Id = 75, Path = "L7KDEUBRUGimg_00000010.jpg", GarmentId = 78},
        new Image() {Id = 76, Path = "PZIAJF4ZGBimg_00000014.jpg", GarmentId = 79},
        new Image() {Id = 77, Path = "EHCL8DPSB5img_00000001.jpg", GarmentId = 82},
        new Image() {Id = 78, Path = "NG519VIGAEimg_00000002.jpg", GarmentId = 83},
        new Image() {Id = 79, Path = "RCPLD22VDVimg_00000008.jpg", GarmentId = 84},
        new Image() {Id = 80, Path = "KMQO2QYEE8img_00000009.jpg", GarmentId = 85},
        new Image() {Id = 81, Path = "UJTGDWG2INimg_00000011.jpg", GarmentId = 86},
        new Image() {Id = 82, Path = "NJX7LIFC0Pimg_00000041.jpg", GarmentId = 87},
        new Image() {Id = 83, Path = "KWGC471BD0img_00000032.jpg", GarmentId = 89},
        new Image() {Id = 84, Path = "HT3VW7XQO1img_00000001.jpg", GarmentId = 90},
        new Image() {Id = 85, Path = "9LQSH0ABB2img_00000001.jpg", GarmentId = 91},
        new Image() {Id = 86, Path = "TVP36Z41NSimg_00000003.jpg", GarmentId = 92},
        new Image() {Id = 87, Path = "HOBCKY7HERimg_00000005.jpg", GarmentId = 93},
        new Image() {Id = 88, Path = "G5C7PVMQFWimg_00000014.jpg", GarmentId = 94},
        new Image() {Id = 89, Path = "OX48VILHVGimg_00000018.jpg", GarmentId = 95},
        new Image() {Id = 90, Path = "118OYM6FH0img_00000039.jpg", GarmentId = 96},
        new Image() {Id = 91, Path = "C45N07XV1Uimg_00000001.jpg", GarmentId = 97},
        new Image() {Id = 92, Path = "VFKSJ71SI5img_00000002.jpg", GarmentId = 98},
        new Image() {Id = 93, Path = "GGOTMWJ4E2img_00000007.jpg", GarmentId = 99},
        new Image() {Id = 94, Path = "WV3V6OHWCSimg_00000016.jpg", GarmentId = 100},
        new Image() {Id = 95, Path = "IWMQ70IV5Timg_00000002.jpg", GarmentId = 101},
        new Image() {Id = 96, Path = "LPXOYHDIZHimg_00000004.jpg", GarmentId = 102},
        new Image() {Id = 97, Path = "7PJSHM8XLUimg_00000007.jpg", GarmentId = 103},
        new Image() {Id = 98, Path = "O1ZBDLDOHAimg_00000012.jpg", GarmentId = 104},
        new Image() {Id = 99, Path = "04XNMWKBZ8img_00000020.jpg", GarmentId = 105},
        new Image() {Id = 100, Path = "DGQS0FALUGimg_00000025.jpg", GarmentId = 106},
        new Image() {Id = 101, Path = "ZOHZLJXT98img_00000001.jpg", GarmentId = 109},
        new Image() {Id = 102, Path = "ZKDODRJWR2img_00000036.jpg", GarmentId = 110},
        new Image() {Id = 103, Path = "2VIGM5HKNZimg_00000037.jpg", GarmentId = 111},
        new Image() {Id = 104, Path = "5ZLBDBGO27img_00000038.jpg", GarmentId = 112},
        new Image() {Id = 105, Path = "01X925DZPYimg_00000002.jpg", GarmentId = 113},
        new Image() {Id = 106, Path = "850OGTMCPLimg_00000004.jpg", GarmentId = 114},
        new Image() {Id = 107, Path = "MFMQ41VKG5img_00000012.jpg", GarmentId = 115},
        new Image() {Id = 108, Path = "UQ1M2RFN3Rimg_00000014.jpg", GarmentId = 116},
        new Image() {Id = 109, Path = "PY1QHT8A06img_00000015.jpg", GarmentId = 117},
        new Image() {Id = 110, Path = "SFDAYZUTDMimg_00000017.jpg", GarmentId = 118},
        new Image() {Id = 111, Path = "R1V4UI58M1img_00000023.jpg", GarmentId = 119},
        new Image() {Id = 112, Path = "BNTDLULJO6img_00000027.jpg", GarmentId = 120},
        new Image() {Id = 113, Path = "E9SGLW0PTGimg_00000055.jpg", GarmentId = 121},
        new Image() {Id = 114, Path = "464VSNWRUKimg_00000058.jpg", GarmentId = 122},
        new Image() {Id = 115, Path = "Q3HQ2RYVL4img_00000060.jpg", GarmentId = 123},
        new Image() {Id = 116, Path = "J3IEFU2KS0img_00000066.jpg", GarmentId = 124},
        new Image() {Id = 117, Path = "XRZQX9DLI1img_00000001.jpg", GarmentId = 125},
        new Image() {Id = 118, Path = "RISZ77KQYDimg_00000003.jpg", GarmentId = 126},
        new Image() {Id = 119, Path = "9542XA26FHimg_00000004.jpg", GarmentId = 127},
        new Image() {Id = 120, Path = "E5L8RND0AVimg_00000008.jpg", GarmentId = 128},
        new Image() {Id = 121, Path = "YDYGAKQM20img_00000010.jpg", GarmentId = 129},
        new Image() {Id = 122, Path = "42WEM98T72img_00000012.jpg", GarmentId = 130},
        new Image() {Id = 123, Path = "R6GKWYY4CCimg_00000030.jpg", GarmentId = 131},
        new Image() {Id = 124, Path = "11Q84N3BDUimg_00000063.jpg", GarmentId = 132},
        new Image() {Id = 125, Path = "A700KUANZ5img_00000016.jpg", GarmentId = 133},
        new Image() {Id = 126, Path = "ZWPFMQ9UV2img_00000001.jpg", GarmentId = 134},
        new Image() {Id = 127, Path = "9Z0EBICDUUimg_00000005.jpg", GarmentId = 135},
        new Image() {Id = 128, Path = "WIGKGIJ2HQimg_00000001.jpg", GarmentId = 136},
        new Image() {Id = 129, Path = "0ZHGUC46W4img_00000055.jpg", GarmentId = 137},
        new Image() {Id = 130, Path = "QK671A20UXimg_00000032.jpg", GarmentId = 138},
        new Image() {Id = 131, Path = "SMS2ZJW84Timg_00000045.jpg", GarmentId = 139},
        new Image() {Id = 132, Path = "NI9B846YKOimg_00000005.jpg", GarmentId = 140},
        new Image() {Id = 133, Path = "Z6Y960IC9Kimg_00000001.jpg", GarmentId = 141}
    };


    public static List<Color> colors = new List<Color>
    {
        new Color() {Id = 1, Name = "Yellow", HEX = "#F1C40F"},
        new Color() {Id = 2, Name = "Orange", HEX = "#F39C12"},
        new Color() {Id = 5, Name = "Blue", HEX = "#2E86C1"},
        new Color() {Id = 9, Name = "Green", HEX = "#229954"},
        new Color() {Id = 10, Name = "Black", HEX = "#000000"},
        new Color() {Id = 14, Name = "Red", HEX = "#B03A2E"},
        new Color() {Id = 24, Name = "Beige", HEX = "#FCF3CF"},
        new Color() {Id = 59, Name = "Pink", HEX = "#F5B7B1"},
        new Color() {Id = 92, Name = "White", HEX = "#FFFFFF"},
    };


    public static Dictionary<long, List<long>> colors_garments = new Dictionary<long, List<long>>
    {
        {1, new List<long>() {1, 2}},
        {2, new List<long>() {3, 1, 4}},
        {4, new List<long>() {5, 6, 2}},
        {5, new List<long>() {6}},
        {6, new List<long>() {5, 7, 6, 3, 8}},
        {7, new List<long>() {9, 5, 7, 6, 3, 2, 8}},
        {8, new List<long>() {5, 7, 1}},
        {9, new List<long>() {5, 3, 4, 2, 8}},
        {10, new List<long>() {9, 5, 3, 2, 8}},
        {11, new List<long>() {9, 5, 7}},
        {12, new List<long>() {6, 3, 8}},
        {13, new List<long>() {5}},
        {14, new List<long>() {9}},
        {15, new List<long>() {5, 3, 2, 8}},
        {16, new List<long>() {9, 5, 7, 3}},
        {17, new List<long>() {9, 5, 7, 6, 2}},
        {18, new List<long>() {9, 5}},
        {19, new List<long>() {9, 5}},
        {20, new List<long>() {9}},
        {21, new List<long>() {9}},
        {22, new List<long>() {9, 5, 7, 3}},
        {23, new List<long>() {5}},
        {24, new List<long>() {5, 7, 6}},
        {25, new List<long>() {8}},
        {26, new List<long>() {9, 7, 8}},
        {27, new List<long>() {5}},
        {28, new List<long>() {2}},
        {29, new List<long>() {6}},
        {30, new List<long>() {8}},
        {31, new List<long>() {9}},
        {32, new List<long>() {3}},
        {33, new List<long>() {9}},
        {34, new List<long>() {9, 5, 3, 8}},
        {35, new List<long>() {7, 3}},
        {36, new List<long>() {5}},
        {37, new List<long>() {9, 3}},
        {38, new List<long>() {6}},
        {39, new List<long>() {5, 6}},
        {40, new List<long>() {6}},
        {41, new List<long>() {5}},
        {42, new List<long>() {3, 4}},
        {43, new List<long>() {5, 6}},
        {44, new List<long>() {8}},
        {45, new List<long>() {9, 5, 6, 3}},
        {46, new List<long>() {6, 3}},
        {47, new List<long>() {3}},
        {48, new List<long>() {6}},
        {49, new List<long>() {3}},
        {50, new List<long>() {5}},
        {51, new List<long>() {4, 2}},
        {52, new List<long>() {5}},
        {53, new List<long>() {9, 3, 1, 4, 2, 8}},
        {54, new List<long>() {9}},
        {55, new List<long>() {9, 6, 3}},
        {56, new List<long>() {9, 6}},
        {57, new List<long>() {5}},
        {58, new List<long>() {9}},
        {59, new List<long>() {5}},
        {60, new List<long>() {5}},
        {61, new List<long>() {9, 3}},
        {62, new List<long>() {8}},
        {63, new List<long>() {5}},
        {64, new List<long>() {3}},
        {65, new List<long>() {3}},
        {66, new List<long>() {4}},
        {67, new List<long>() {9, 2}},
        {68, new List<long>() {9, 5, 1}},
        {69, new List<long>() {9}},
        {70, new List<long>() {6, 3}},
        {71, new List<long>() {9, 3}},
        {74, new List<long>() {9, 6}},
        {75, new List<long>() {6, 4}},
        {76, new List<long>() {9, 6, 3}},
        {77, new List<long>() {3}},
        {78, new List<long>() {3}},
        {79, new List<long>() {9, 5}},
        {82, new List<long>() {9, 5}},
        {83, new List<long>() {9, 5}},
        {84, new List<long>() {9, 3}},
        {85, new List<long>() {9}},
        {86, new List<long>() {7}},
        {87, new List<long>() {6}},
        {89, new List<long>() {9}},
        {90, new List<long>() {9, 3}},
        {91, new List<long>() {9, 5}},
        {92, new List<long>() {9, 3, 1}},
        {93, new List<long>() {9, 5}},
        {94, new List<long>() {9, 5, 8}},
        {95, new List<long>() {9, 5, 3, 1}},
        {96, new List<long>() {9, 6}},
        {97, new List<long>() {9}},
        {98, new List<long>() {7}},
        {99, new List<long>() {7}},
        {100, new List<long>() {3}},
        {101, new List<long>() {3}},
        {102, new List<long>() {9}},
        {103, new List<long>() {3}},
        {104, new List<long>() {9, 6, 3}},
        {105, new List<long>() {9, 5, 3, 8}},
        {106, new List<long>() {5, 6, 3}},
        {109, new List<long>() {5, 7, 6, 3}},
        {110, new List<long>() {9, 5, 7, 3}},
        {111, new List<long>() {9, 7, 3}},
        {112, new List<long>() {9, 5, 7, 6, 4, 8}},
        {113, new List<long>() {5}},
        {114, new List<long>() {3}},
        {115, new List<long>() {5}},
        {116, new List<long>() {3}},
        {117, new List<long>() {3}},
        {118, new List<long>() {3}},
        {119, new List<long>() {3}},
        {120, new List<long>() {9}},
        {121, new List<long>() {5}},
        {122, new List<long>() {3}},
        {123, new List<long>() {3}},
        {124, new List<long>() {9, 3}},
        {125, new List<long>() {3}},
        {126, new List<long>() {9}},
        {127, new List<long>() {3}},
        {128, new List<long>() {9}},
        {129, new List<long>() {9}},
        {130, new List<long>() {3}},
        {131, new List<long>() {9}},
        {132, new List<long>() {3}},
        {133, new List<long>() {9, 5, 7, 3}},
        {134, new List<long>() {3}},
        {135, new List<long>() {3}},
        {136, new List<long>() {5, 3}},
        {137, new List<long>() {3}},
        {138, new List<long>() {9, 6, 3}},
        {139, new List<long>() {9, 1}},
        {140, new List<long>() {9, 5, 6}},
        {141, new List<long>() {5, 3}},
    };

    public static List<Size> sizes = new List<Size>
    {
        new Size() {Id = 1, Name = "S", CM = 90, CategoryId = 2},
        new Size() {Id = 2, Name = "M", CM = 98, CategoryId = 2},
        new Size() {Id = 3, Name = "L", CM = 110, CategoryId = 2},
        new Size() {Id = 4, Name = "XL", CM = 120, CategoryId = 2},

        new Size() {Id = 5, Name = "S", CM = 90, CategoryId = 5},
        new Size() {Id = 6, Name = "M", CM = 98, CategoryId = 5},
        new Size() {Id = 7, Name = "L", CM = 110, CategoryId = 5},
        new Size() {Id = 8, Name = "XL", CM = 120, CategoryId = 5},

        new Size() {Id = 9, Name = "S", CM = 90, CategoryId = 7},
        new Size() {Id = 10, Name = "M", CM = 98, CategoryId = 7},
        new Size() {Id = 11, Name = "L", CM = 110, CategoryId = 7},
        new Size() {Id = 12, Name = "XL", CM = 120, CategoryId = 7},

        new Size() {Id = 9, Name = "28-31", CM = 75, CategoryId = 1},
        new Size() {Id = 10, Name = "32-34", CM = 85, CategoryId = 1},
        new Size() {Id = 11, Name = "34-36", CM = 95, CategoryId = 1},
        new Size() {Id = 12, Name = "36-38", CM = 105, CategoryId = 1},


        new Size() {Id = 9, Name = "28-31", CM = 75, CategoryId = 4},
        new Size() {Id = 10, Name = "32-34", CM = 85, CategoryId = 4},
        new Size() {Id = 11, Name = "34-36", CM = 95, CategoryId = 4},
        new Size() {Id = 12, Name = "36-38", CM = 105, CategoryId = 4},
    };

    public static Dictionary<string, List<string>> shapes = new Dictionary<string, List<string>>
    {
        {
            "Inverted triangle",
            new List<string>()
            {
                "Layered", "Bias", "A line", "box pleated", "tulip", "low waist", "Flared leg", "Deep V neck",
                "Two colors", "wrap", "wide leg loose", "two colors", "scoop neck", "scalloped", "one shoulder",
                "off the shoulder", "maxi dress", "m slit", "cap-sleeve", "button-front", "boat neck", "Twisted-Hem",
                "Tartan", "Tab-Sleeved", "southwestern-patterned", "Plaid", "Peasant", "dolphin hem", "Butterfly",
                "Speckled", "Woven", "Windowpane", "V-Neck", "Twist-Front", "Split-Neck", "Slub", "Sleek", "Side-slit",
                "Pleated-Front", "Pleated", "notched collar", "high-slit", "H-Striped", "drop-sleeve", "Draped",
                "double-breasted", "Dolman", "deep v-neck", "Crochet", "Crepe", "Collarless", "Cinched Waist",
                "Check-Patterned", "Boxy", "Belted", "Batwing", "asymmetrical hem sweater", "asymmetrical hem halter",
                "asymmetric", "Round neck", "raglan sleeve", "plaid", "peplum", "Lace-Paneled", "lace", "Floral",
                "Wide-Leg", "Side Slit", "Flared", "Distressed", "Cuffed Hem", "Boyfriend", "Tweed", "Surplice Neck",
                "Midi", "Long", "gathered waistline", "chiffon", "pleated", "paneled", "maxi", "cargo", "capri",
                "Button-Up", "box-pleated", "A-line", "bootcut", "low back bow", "mesh ", "ankle", "dolphin hem",
                "flat front", "flounce", "high waist", "side slit pants", "Vented", "asymmetrical hem dress",
                "asymmetrical hem jeans", "asymmetrical hem skirt"
            }
        },
        {
            "Triangle",
            new List<string>()
            {
                "Panelled", "full", "Bias", "A line", "tulip", "high waist", "Two colors", "Culottes", "asymmetric",
                "strapless", "wide leg loose", "off the shoulder", "mock neck", "cap-sleeve", "button-front",
                "V-Striped", "Twisted-Hem", "Tassel", "Tartan", "Tab-Sleeved", "southwestern-patterned", "racerback",
                "Plaid", "Peasant", "draped shawl", "Speckled", "zipper", "Woven", "Windowpane", "Twist-Front",
                "turtle-neck", "Tie-Front", "Split-Neck", "Split-Back", "Slub", "Sleek", "Side-slit", "Shirred",
                "Pleated-Front", "Open-Knit", "Pleated", "notched collar", "illusion neckline", "High-neck",
                "high waist", "fringe", "tassel", "drop-sleeve", "drop waist", "drawstring", "Draped", "drape-front",
                "Crochet", "Crepe", "color block pocket", "Collarless", "Collared", "Cinched top", "Cinched Waist",
                "Check-Patterned", "caged", "Buttoned", "Boxy", "Belted", "bell-sleeve", "beaded collar", "Batwing",
                "Round neck", "Puff Sleeve", "plaid", "peplum", "Lace-Paneled", "lace", "Wide-Leg", "Floral", "Flared",
                "Fit", "Cuffed Hem", "Boyfriend", "Tweed", "Turtleneck", "suspender", "Square", "Short Sleeve",
                "Shawl collar", "Puff sleeves", "Midi", "Long", "gathered waistline", "chiffon", "pleated", "paneled",
                "maxi", "cargo", "capri", "Button-Up", "box-pleated", "bodycon", "beaded collar", "A-line", "bootcut",
                "mesh ", "t-back dress", "tulip-back", "V-Back", "dolphin hem", "flat front", "flounce", "high waist"
            }
        },
        {
            "Rectangle",
            new List<string>()
            {
                "pencil", "bubble", "full", "Layered", "A line", "low waist", "peplum", "drawstring", "ruffle",
                "belted", "straight leg", "wide leg", "two colors", "strapless", "scoop neck", "scalloped",
                "off the shoulder", "maxi dress", "m slit", "boat neck", "Tab-Sleeved", "racerback", "Butterfly",
                "Speckled", "Woven", "V-Neck", "turtle-neck", "Twist-Front", "Tie-Front", "Slub", "Sleeveless", "Sleek",
                "Pleated-Front", "notched collar", "Pleated", "illusion neckline", "High-neck", "H-Striped", "fringe",
                "tassel", "drop-sleeve", "drawstring", "Draped", "drape-front", "double-breasted", "Crochet", "Crepe",
                "color block pocket", "Collarless", "Collared", "caged", "Belted", "beaded collar", "Cinched Waist",
                "Round neck", "raglan sleeve", "Puff Sleeve", "Distressed", "peplum", "Lace-Paneled", "lace", "Flared",
                "Fit", "Cuffed Hem", "Tweed", "Turtleneck", "suspender", "Surplice Neck", "Short Sleeve",
                "Puff sleeves", "chiffon", "Midi", "", "gathered waistline", "pleated", "paneled", "maxi", "capri",
                "Skinny", "Crop", "bootcut", "mesh ", "tulip-back", "V-Back", "ankle", "dolphin hem", "Vented"
            }
        },
        {
            "Hourglass",
            new List<string>()
            {
                "pencil", "full", "A line", "tulip", "high waist", "Flared leg", "strapless", "drawstring", "ruffle",
                "belted", "straight leg", "wrap", "wide leg loose", "wide leg", "two colors", "strapless", "scoop neck",
                "scalloped", "off the shoulder", "maxi dress", "m slit", "V-Striped", "Twisted-Hem", "racerback",
                "Speckled", "Woven", "Split-Neck", "Split-Back", "Twist-Front", "Slub", "Sleeveless", "Sleek",
                "Side-slit", "Shirred", "sheer", "Pleated-Front", "Open-Knit", "notched collar", "Pleated",
                "illusion neckline", "high-slit", "High-neck", "high waist", "H-Striped", "drawstring", "Draped",
                "drape-front", "double-breasted", "Crochet", "Crepe", "Collarless", "Collared", "Cinched top", "caged",
                "Buttoned", "Belted", "beaded collar", "Cinched Waist", "Round neck", "raglan sleeve", "Long Sleeve",
                "Wide-Leg", "peplum", "Side Slit", "lace", "Lace-Paneled", "Cuffed Hem", "Distressed", "Flared", "Fit",
                "Tweed", "suspender", "Surplice Neck", "Square", "Short Sleeve", "Long", "chiffon", "Midi",
                "gathered waistline", "capri", "pleated", "paneled", "maxi", "Button-Up", "bodycon", "beaded collar",
                "Skinny", "Crop", "bootcut", "mesh ", "t-back dress", "tulip-back", "V-Back", "ankle", "high waist",
                "side slit pants", "Vented"
            }
        },
        {
            "Apple",
            new List<string>()
            {
                "flip", "Bias", "A line", "low waist", "pleated flare", "wrap", "empire", "Vertical stripes",
                "wide leg loose", "wide leg", "two colors", "scoop neck", "scalloped", "off the shoulder", "cap-sleeve",
                "button-front", "boat neck", "Twisted-Hem", "Tartan", "Tab-Sleeved", "Plaid", "Peasant", "dolphin hem",
                "Speckled", "V-Neck", "Split-Neck", "Slub", "Sleek", "Shirred", "Twist-Front", "sheer",
                "notched collar", "drop-sleeve", "drop waist", "Pleated", "Draped", "drape-front", "Dolman",
                "deep v-neck", "Crepe", "color block pocket", "Collarless", "Collared", "Buttoned", "beaded collar",
                "asymmetrical hem sweater", "asymmetrical hem halter", "asymmetric", "raglan sleeve", "Floral",
                "Wide-Leg", "Cuffed Hem", "Boyfriend", "Distressed", "Flared", "Fit", "suspender", "Surplice Neck",
                "Square", "Short Sleeve", "Long", "chiffon", "Button-Up", "Midi", "pleated", "paneled", "maxi",
                "beaded collar", "A-line", "bootcut", "mesh ", "dolphin hem", "flat front", "flounce",
                "asymmetrical hem dress", "asymmetrical hem jeans", "asymmetrical hem skirt"
            }
        }
    };
    
   public static List<User> users = new List<User>()
   {
       new User(){FirstName = "Test User 1", LastName = "Test Uesr 1", Email = "testuser1@gmail.com", EmailConfirmed = true, UserName = "testusre1"},
       new User(){FirstName = "Test User 2", LastName = "Test Uesr 2", Email = "testuser2@gmail.com", EmailConfirmed = true, UserName = "testusre2"}
   };



   public static List<Store> stores = new List<Store>()
   {
       new Store() {Id = 1, Name = "first Store", IsApprove = true, UserId = 2},
       new Store() {Id = 2, Name = "second Store", IsApprove = true, UserId = 3}
   };
        
        
    public static List<Location> locations = new List<Location>()
    {
        new Location(){Id = 1, City = "Amman", Country = "Jordan", StoreId = 1, Street = "Street xxx", PhoneNumaber = "079275755"}, 
        new Location(){Id = 1, City = "Irbed", Country = "Jordan", StoreId = 2, Street = "Street yyy", PhoneNumaber = "079275756"}, 
    };
    

}