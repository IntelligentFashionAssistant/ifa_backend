using System;
using System.Collections.Generic;


namespace domain.Entitys
{
    public class Property
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public long? GroupId { get; set; }
        public Group? Group { get; set; }
        public ICollection<Garment> Garments { get; set; }
        public ICollection<Image> Images { get; set; }
        public ICollection<Shape> Shapes { get; set; }

        //Constracter
        public Property()
        {
            Garments = new HashSet<Garment>();
            Images = new HashSet<Image>();
            Shapes = new HashSet<Shape>();
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is not Property) return false;
            return ((Property) obj).Id == this.Id;
        }
    }
}
