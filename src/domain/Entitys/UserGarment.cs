using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Entitys
{
    public class UserGarment
    {
        public long GarmentId { get; set; }
        public long UserId { get; set; }

        public User User { get; set; }
        public Garment Garment { get; set; }
    }
}
