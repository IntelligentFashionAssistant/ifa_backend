using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Entitys
{
   public class Location
    {
        public int ID { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }   
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int StoreId { get; set; }
        public Store Store { get; set; }
    }
}
