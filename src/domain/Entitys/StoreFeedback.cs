using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Entitys
{
   public class StoreFeedback
    {
        public long Id { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public float Rate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        //public long StoreId { get; set; }
        //public Store Store { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }

    }
}
