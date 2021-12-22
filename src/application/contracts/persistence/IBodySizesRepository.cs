using domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.persistence
{
    public interface IBodySizesRepository : IRepository<BodySizes, long>
    {
    }
}
