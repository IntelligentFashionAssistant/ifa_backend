namespace ifa_front.Models
{
    public class Property
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public long GroupId { get; set; }
        public long CategoryId { get; set; }
        public string Group { get; set; }
        public string Category { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Group> Groups { get; set; }
    }
}
