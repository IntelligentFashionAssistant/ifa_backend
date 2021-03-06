using System.Collections.Generic;

namespace domain.Entitys
{
    public class Group
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        //public long CategoryId { get; set; }
        //public Category Category { get; set; }

        public ICollection<Category> Categories { get; set; }
        public ICollection<Property> Properties { get; set; }

        public Group()
        {
            Properties = new HashSet<Property>();
            Categories = new HashSet<Category>();
        }

    }
}