using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.services
{
    public class LocationDto
    {
        public long Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PhoneNumaber { get; set; }
        public long StoreId { get; set; }
    }
}
