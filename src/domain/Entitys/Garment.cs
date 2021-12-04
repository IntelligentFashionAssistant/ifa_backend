using System;
using System.Collections.Generic;

namespace domain.Entitys
{
    public class Garment
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        //public long StoreId { get; set; }
        //public Store Store { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public long CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Color> Colors { get; set; }
        public ICollection<Property> Properties { get; set; }
        public ICollection<Image> Images { get; set; }
        
        public ICollection<Shape> Shapes { get; set; }
        //Constracter
        public Garment()
        {
            Colors = new HashSet<Color>();
            Properties = new HashSet<Property>();
            Images = new HashSet<Image>();
            Shapes = new HashSet<Shape>();
        }
    }
}
