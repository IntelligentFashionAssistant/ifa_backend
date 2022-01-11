using domain.Entitys;

namespace application.persistence
{
    public interface IStoreRepository : IAsnycRepository<Store, long>
    {
        Task<long> GetByUserId(long userId);
    }
}