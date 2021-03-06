using System;
using System.Collections.Generic;

namespace application.DTOs
{
    public class PropertyDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long? GroupId { get; set; }
        public string Group { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<string> Images { get; set; }
     
    }
}