using System;


namespace domain.Entitys
{
   public class Location
    {
        public long Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }   
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public long StoreId { get; set; }
        public Store Store { get; set; }
    }
}
