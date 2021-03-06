using domain.Entitys;

namespace application.persistence
{
    public interface IStoreRepository : IAsnycRepository<Store, long>
    {
        Task<long> GetByUserId(long userId);
        ICollection<Garment> GetGarmentsByCategory(long categoryId, long storeId);
        bool Approved(long storeId);
        Task<ICollection<Store>> GetAllNotApproved();
        Task<string> AddPhoto(string photo, long storeId);
        Task<Store> Profile(long storeId);
        Task<Store> GetByIdWithGarments(long id, List<long>garmentIds);

        bool CheckApprove(long userId);
        ICollection<StoreFeedback> GetAllFeedbacks(long stroeId);
        //Task<bool> Cancel(long storeId);
    }
}