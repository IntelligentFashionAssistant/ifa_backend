﻿using System;
using System.Collections.Generic;

namespace domain.Entitys
{
    public class Garment
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Color> Colors { get; set; }
        public ICollection<Property> Properties { get; set; }
        public ICollection<Image> Images { get; set; }
        public ICollection<Store> Stores { get; set; }
        public ICollection<Shape_Garment> Shape_Garments { get; set; }
        //Constracter
        public Garment()
        {
            Colors = new HashSet<Color>();
            Properties = new HashSet<Property>();
            Images = new HashSet<Image>();
            Stores = new HashSet<Store>();
            Shape_Garments = new HashSet<Shape_Garment>();
        }
    }
}
