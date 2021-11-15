using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Entitys
{
   public class Store
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ICollection<Location> Locations { get; set; }
        public ICollection<StoreFeedback> StoreFeedbacks { get; set; }

        //Constracter
        public Store()
        {
            Locations = new HashSet<Location>();
            StoreFeedbacks = new HashSet<StoreFeedback>();
        }
    }
}
