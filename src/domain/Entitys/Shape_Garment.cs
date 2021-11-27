using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Entitys
{
    public class Shape_Garment
    {
        public int ID { get; set; }
        public int ShapeId { get; set; }
        public Shape Shape { get; set; }
        public int GarmentId { get; set; }
        public Garment Garment { get; set; }
        public float CompatibilityRatio { get; set; }
    }
}
