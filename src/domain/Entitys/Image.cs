using System;


namespace domain.Entitys
{
    public class Image
    {
        public long Id { get; set; }
        public string Path { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public long GarmentId { get; set; }
        public Garment Garment { get; set; }
        public long PropertyId { get; set; }
        public Property Property { get; set; }
    }
}
