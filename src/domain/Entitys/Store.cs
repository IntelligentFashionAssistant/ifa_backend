using System;
using System.Collections.Generic;


namespace domain.Entitys
{
   public class Store
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public long UserId { get; set; }
        public User User { get; set; }
        public ICollection<Location> Locations { get; set; }
        public ICollection<StoreFeedback> StoreFeedbacks { get; set; }
        public ICollection<Garment> Garments { get; set; }

        //Constracter
        public Store()
        {
            Locations = new HashSet<Location>();
            StoreFeedbacks = new HashSet<StoreFeedback>();
            Garments = new HashSet<Garment>();
        }
    }
}
