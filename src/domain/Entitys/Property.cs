using System;
using System.Collections.Generic;


namespace domain.Entitys
{
    public class Property
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public ICollection<Garment> Garments { get; set; }
        public ICollection<Image> Images { get; set; }
        public ICollection<PropertyFeedback> PropertyFeedbacks { get; set; }
        public ICollection<Shape_Property> Shape_Properties { get; set; }

        //Constracter
        public Property()
        {
            Garments = new HashSet<Garment>();
            Images = new HashSet<Image>();
            PropertyFeedbacks = new HashSet<PropertyFeedback>();
            Shape_Properties = new HashSet<Shape_Property>();
        }
    }
}
