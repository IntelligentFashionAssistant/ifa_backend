using System.Collections.Generic;
using System.Security.Claims;
using application.DTOs;

namespace application.services
{
    public interface IGarmentService : IService<GarmentDto, long>
    {
        Task<ICollection<GarmentDto>> GetUserGarments(ClaimsPrincipal userClaim, long categoryId);
        Task<ICollection<GarmentDto>> GetUserGarments(ClaimsPrincipal userClaim);
        Task LikeOrDislikeGarment(ClaimsPrincipal user, long garmentId);
    }
}