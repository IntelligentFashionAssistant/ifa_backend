using application.DTOs;

namespace application.services
{
    public interface IStoreService : IAsnycService<StoreDto, long>
    {
        //void RateGarment(StoreRatingDto storeRatingDto);
    }
}