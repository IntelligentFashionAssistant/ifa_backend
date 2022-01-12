using domain.Entitys;

namespace application.persistence
{
    public interface IStoreRepository : IAsnycRepository<Store, long>
    {
        Task<long> GetByUserId(long userId);
        ICollection<Garment> GetGarmentsByCategory(long categoryId, long storeId);
        bool Approved(long storeId);
        Task<ICollection<Store>> GetAllNotApproved();
    }
}