namespace api.ApiDTOs
{
    public class StoreApiDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? BirthDate { get; set;}
        public string StoreName { get; set; }
        public string? StroePhoto { get; set; }
        public float Rank { get; set; }
        public string Username { get; set; }
        public ICollection<LocationApiDto>? Locations { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<StoreFeedbackApiDto>? StoreFeedbacks { get; set; }
        public ICollection<GarmentApiDto>? Garments { get; set; }
    }
}
