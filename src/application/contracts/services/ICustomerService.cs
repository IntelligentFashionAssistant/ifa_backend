using System.Collections.Generic;
using System.Security.Claims;
using api.ApiDTOs;
using application.DTOs;

namespace application.services
{
    public interface ICustomerService : IAsnycService<CustomerDto, long>
    {
        Task<CustomerDto> CalculateBodyShape(ClaimsPrincipal userClaim, BodySizesDto bodySizesDto);
        Task<CustomerDto> Profile(ClaimsPrincipal userClaim);
    }
}