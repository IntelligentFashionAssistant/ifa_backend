using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.DTOs
{
    public class SizeDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int CM { get; set; }
        public long? CategoryId { get; set; }
    }
}
