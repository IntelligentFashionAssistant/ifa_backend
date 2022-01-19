using application.services;
using domain.Entitys;

namespace application.persistence;

public interface ISizeRepository : IRepository<Size, long>
{
    ICollection<Size> GetByCategoryId(long categoryId);

    ICollection<Size> GetSizeByUserId(long id);
}