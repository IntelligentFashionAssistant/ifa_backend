using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;


namespace domain.Entitys
{
    public class User : IdentityUser<long>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public long? BodySizesId { get; set; }
        public BodySizes? BodySizes { get; set; }
        public long? ShapeId { get; set; }
        public Shape? Shape { get; set; }
        
        public ICollection<Size> Sizes { get; set; }
        public ICollection<Garment> Garments { get; set; }

        public User()
        {
            Sizes = new HashSet<Size>();
            Garments = new HashSet<Garment>();
        }
    }
}
