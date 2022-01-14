namespace api.ApiDTOs
{
    public class LocationApiDto
    {
        public long Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PhoneNumber { get; set; }
        public long StoreId { get; set; }
    }
}
