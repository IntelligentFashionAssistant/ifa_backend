using System.Collections.Generic;

namespace application.services
{
    public interface IService<TE, TK>
    {
        TE GetById(TK id);
        ICollection<TE> GetAll();
        TE Create(TE obj);
        TE Edit(TE obj);
        bool DeleteById(TK id);
    }
}