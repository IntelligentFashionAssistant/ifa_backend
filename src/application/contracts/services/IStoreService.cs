using application.DTOs;

namespace application.services
{
    public interface IStoreService : IService<StoreDto, long>
    {
        void RateGarment(StoreRatingDto storeRatingDto);
    }
}