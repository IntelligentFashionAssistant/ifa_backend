using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Entitys
{
    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Group> Groups { get; set; }
        public ICollection<Garment> Garments { get; set; }

        public Category()
        {
            Garments = new HashSet<Garment>(); 
            Groups = new HashSet<Group>();
        }
    }
}
//dotnet ef database update
// dotnet ef migration add 'v5'