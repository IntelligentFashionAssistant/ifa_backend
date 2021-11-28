using System;


namespace domain.Entitys
{
    public class Shape_Property
    {
        public long ShapeId { get; set; }
        public Shape Shape { get; set; }
        public long PropertyId { get; set; }
        public Property Property { get; set; }
        public float CompatibilityRatio { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
