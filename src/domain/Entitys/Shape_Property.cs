using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Entitys
{
    public class Shape_Property
    {
        public int ShapeId { get; set; }
        public Shape Shape { get; set; }
        public int PropertyId { get; set; }
        public Property Property { get; set; }
        public float CompatibilityRatio { get; set; }
    }
}
