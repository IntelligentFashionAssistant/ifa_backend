using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Entitys
{
    public class PropertyFeedback
    {
        //TODO
        public int ID { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int PropertyId { get; set; }
        public Property Property { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
