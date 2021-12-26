using System.Collections.Generic;

namespace application.DTOs
{
    public class StoreDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public string StoreName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public CustomerDto Customer { get; set; }
        public ICollection<LocationDto> Locations { get; set; }
    }
}