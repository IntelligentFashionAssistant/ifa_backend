using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.DTOs
{
    public class StoreCancelDto
    {

        public long StoreId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
