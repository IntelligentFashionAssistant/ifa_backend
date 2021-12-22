using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.DTOs
{
    public class BodySizesDto
    {
        public long Id { get; set; }
        public float ShoulderRange { get; set; }
        public float BustRange { get; set; }
        public float HipRange { get; set; }
        public float WaistRange { get; set; }
    }
}
