using System.Security.Claims;
using application.DTOs;

namespace application.services
{
    public interface IStoreService : IAsnycService<StoreDto, long>
    {
        Task RateStore(ClaimsPrincipal claimsPrincipal, StoreFeedbackDto storeFeedbackDto);
        Task<long> GetStoreByUserId(long userId);
        Task<ICollection<GarmentDto>> GetGarmentsByCategory(ClaimsPrincipal claimsPrincipal, long categoryId);
    }
}