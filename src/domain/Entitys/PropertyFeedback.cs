using System;


namespace domain.Entitys
{
    public class PropertyFeedback
    {
        //TODO
        public long Id { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public long PropertyId { get; set; }
        public Property Property { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
