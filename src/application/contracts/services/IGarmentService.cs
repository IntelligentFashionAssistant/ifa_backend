using System.Collections.Generic;
using System.Security.Claims;
using application.DTOs;

namespace application.services
{
    public interface IGarmentService : IService<GarmentDto, long>
    {
        Task<ICollection<GarmentDto>> GetUserGarmentsByKeyword(ClaimsPrincipal userClaim, string searchKeyword, int pageNumber, int pageSize);
        Task<ICollection<GarmentDto>> GetUserGarmentsByCategory(ClaimsPrincipal userClaim, long categoryId, int pageNumber, int pageSize);
        Task<ICollection<GarmentDto>> GetUserGarments(ClaimsPrincipal userClaim, int pageNumber, int pageSize);
        Task LikeOrDislikeGarment(ClaimsPrincipal user, long garmentId);
    }
}