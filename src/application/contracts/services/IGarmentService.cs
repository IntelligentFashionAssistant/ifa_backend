using System.Collections.Generic;
using application.DTOs;

namespace application.services
{
    public interface IGarmentServices : IService<GarmentDto, long>
    {
        void RateGarment(GarmentRatingDto garmentRatingDto);
    }
}