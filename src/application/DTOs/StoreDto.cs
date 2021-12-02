using System.Collections.Generic;

namespace application.DTOs
{
    public class StoreDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public UserDto User { get; set; }
        public ICollection<LocationDto> Locations { get; set; }
    }
}