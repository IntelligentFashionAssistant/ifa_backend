﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Entitys
{
   public class ShopOwner
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}