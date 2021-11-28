using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Entitys
{
    public class Shape_Garment
    {
        public long Id { get; set; }
        public long ShapeId { get; set; }
        public Shape Shape { get; set; }
        public long GarmentId { get; set; }
        public Garment Garment { get; set; }
        public float CompatibilityRatio { get; set; }
    }
}
