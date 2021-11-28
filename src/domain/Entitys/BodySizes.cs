using System;


namespace domain.Entitys
{
   public class BodySizes
    {
        public long Id { get; set; }
        public float ShoulderRange { get; set; }
        public float BustRange { get; set; }
        public float HipRange { get; set; }
        public float WaistRange { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
