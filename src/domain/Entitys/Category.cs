using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Entitys
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Property> Properties { get; set; }
        public ICollection<Garment> Garments { get; set; }

        public Category()
        {
            Properties = new HashSet<Property>();
            Garments = new HashSet<Garment>(); 
        }
    }
}
