
using System.Security.Claims;

namespace application.services
{
    public interface ILocationService : IAsnycService<LocationDto,long>
    {
        Task<ICollection<LocationDto>> GetLocationsToStore(ClaimsPrincipal claimsPrincipal);
        Task<LocationDto> CreateLocation(LocationDto obj , ClaimsPrincipal claimsPrincipal);
        Task<LocationDto> EditLocation(LocationDto obj, ClaimsPrincipal claimsPrincipal);
    }
}
