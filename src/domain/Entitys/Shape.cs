using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Entitys
{
    public class Shape
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public float Shoulder_range { get; set; }
        public float BustRange { get; set; }
        public float HipRange { get; set; }
        public float WaistRange { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ICollection<Shape_Property> Shape_Properties { get; set; }

        //Constracter
        public Shape()
        {
            Shape_Properties = new HashSet<Shape_Property>();
        }
    }
}
