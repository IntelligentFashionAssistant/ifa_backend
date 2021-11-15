using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Entitys
{
    public class Garment
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int ShopOwnerId { get; set; }
        public ShopOwner ShopOwner { get; set; }
        public ICollection<Color> Colors { get; set; }
        public ICollection<Property> Properties { get; set; }
        public ICollection<Image> Images { get; set; }

        //Constracter
        public Garment()
        {
            Colors = new HashSet<Color>();
            Properties = new HashSet<Property>();
            Images = new HashSet<Image>();
        }
    }
}
