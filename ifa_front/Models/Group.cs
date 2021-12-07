using Microsoft.AspNetCore.Mvc.Rendering;

namespace ifa_front.Models
{
    public class Group
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long CategoryId { get; set; }
        public string? Category { get; set; }
        public ICollection<Category>? Categorys { get; set; }
    }
}
