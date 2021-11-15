using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Entitys
{
    public class Color
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ICollection<Garment> Garments { get; set; }

        //Constracter
        public Color()
        {
            Garments = new HashSet<Garment>();
        }
    }
}
