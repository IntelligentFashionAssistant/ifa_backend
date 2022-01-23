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
        ICollection<ColorDto> GetColors();
        ICollection<SizeDto> GetSizeByCategory(long categoryId);
        Task<ICollection<GarmentDto>> GetGarmentFavoriteToUser(ClaimsPrincipal userClaim);
        GarmentDto GetUserById(long id);
        Task<ICollection<long>> GetUserGarmentsByStoreId(ClaimsPrincipal userClaim, long StoreId, int pageNumber, int pageSize);
    }
}