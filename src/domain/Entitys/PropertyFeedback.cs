using System;


namespace domain.Entitys
{
    public class PropertyFeedback
    {
        //TODO
        public int ID { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int PropertyId { get; set; }
        public Property Property { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
