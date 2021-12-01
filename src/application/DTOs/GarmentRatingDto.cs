using System.Collections.Generic;

namespace application.DTOs
{
    public class GarmentRatingDto
    {
        public long UserId { get; set; }
        public long GarmentId { get; set; }
        public ICollection<PropertyRating> PropertyRatings { get; set; }
    }

    public class PropertyRating
    {
        public long PropertyId { get; set; }
        // TODO : find better name 
        public float CompatibilityRatio { get; set; }
    }
}