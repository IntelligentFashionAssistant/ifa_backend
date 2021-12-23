using application.DTOs;
using application.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.contracts.services
{
    public interface IBodySizesService : IService<BodySizesDto, long>
    {
        string CreateBody(BodySizesDto obj);
        string EditBody(BodySizesDto obj);
    }
}
