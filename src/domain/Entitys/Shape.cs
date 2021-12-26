using System;
using System.Collections.Generic;


namespace domain.Entitys
{
    public class Shape
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ICollection<Property> Properties { get; set; }
        public ICollection<Garment> Garments { get; set; }
        //Constracter
        public Shape()
        {
            Properties = new HashSet<Property>();
            Garments = new HashSet<Garment>();
        }
    }
}
