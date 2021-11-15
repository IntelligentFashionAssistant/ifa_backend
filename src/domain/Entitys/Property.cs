using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Entitys
{
    public class Property
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ICollection<Garment> Garments { get; set; }
        public ICollection<PropertyDesign> PropertyDesigns { get; set; }

        //Constracter
        public Property()
        {
            Garments = new HashSet<Garment>();
            PropertyDesigns = new HashSet<PropertyDesign>();
        }
    }
}
