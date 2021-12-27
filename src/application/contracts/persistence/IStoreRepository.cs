using domain.Entitys;

namespace application.persistence
{
    public interface IStoreRepository : IAsnycRepository<Store, long>
    {
        Task<Store> GetByUserId(long userId);
    }
}