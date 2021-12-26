using System;


namespace domain.Entitys
{
   public class BodySizes
    {
        public long Id { get; set; }
        public float ShoulderSize { get; set; }
        public float BustSize { get; set; }
        public float HipSize { get; set; }
        public float WaistSize { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
