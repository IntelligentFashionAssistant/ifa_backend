using System;


namespace domain.Entitys
{
    public class Shape_Property
    {
        public int ShapeId { get; set; }
        public Shape Shape { get; set; }
        public int PropertyId { get; set; }
        public Property Property { get; set; }
        public float CompatibilityRatio { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
