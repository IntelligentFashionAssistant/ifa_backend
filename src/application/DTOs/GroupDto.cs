using System.Collections.Generic;

namespace application.DTOs
{
    public class GroupDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public long CategoryId { get; set; }
        public ICollection<string>? CategorysNames { get; set; }
        public ICollection<PropertyDto>? Propertys { get; set; }
        public ICollection<long>? Categorys { get; set; }
    }
}