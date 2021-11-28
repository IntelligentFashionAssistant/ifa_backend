using System.Collections.Generic;
using application.DTOs;

namespace application.services
{
    public interface IGarmentServices : IService<GarmentDto, long>
    {
        long RateGarment(GarmentRatingDto garmentRatingDto);
    }
}