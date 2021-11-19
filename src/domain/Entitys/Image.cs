﻿using System;


namespace domain.Entitys
{
    public class Image
    {
        public int ID { get; set; }
        public string Path { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int GarmentId { get; set; }
        public Garment Garment { get; set; }
        public int PropertyId { get; set; }
        public Property Property { get; set; }
    }
}
