using System;
using System.Collections.Generic;


namespace domain.Entitys
{
    public class Color
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string HEX { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ICollection<Garment> Garments { get; set; }

        //Constracter
        public Color()
        {
            Garments = new HashSet<Garment>();
        }
    }
}
