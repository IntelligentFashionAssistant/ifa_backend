using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Entitys
{
    public class Image
    {
        public int ID { get; set; }
        public string Path { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int GarmentId { get; set; }
        public Garment Garment { get; set; }
    }
}
