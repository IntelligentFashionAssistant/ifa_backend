using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Entitys
{
   public class Customer
    {
        public int ID { get; set; }
        public float ShoulderRange { get; set; }
        public float BustRange { get; set; }
        public float HipRange { get; set; }
        public float WaistRange { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
