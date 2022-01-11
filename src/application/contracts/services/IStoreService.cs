using System.Security.Claims;
using application.DTOs;

namespace application.services
{
    public interface IStoreService : IAsnycService<StoreDto, long>
    {
        Task RateStore(ClaimsPrincipal claimsPrincipal, StoreFeedbackDto storeFeedbackDto);
        ICollection<GarmentDto> GetAllGarments(ClaimsPrincipal claimsPrincipal);
        Task<long> GetStoreByUserId(long userId);
    }
}