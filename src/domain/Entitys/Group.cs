using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Entitys;

    public class Group
    {
    public int ID { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }

    public ICollection<Property> Properties { get; set; }

    public Group()
    {
        Properties = new HashSet<Property>();
    }

}

