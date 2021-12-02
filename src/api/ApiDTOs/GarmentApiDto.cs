namespace api.ApiDTOs
{
    public class GarmentApiDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public long StoreId { get; set; }
        public long CategoryId { get; set; }
        public string? Category { get; set; }
        public ICollection<string> Colors { get; set; }
        public ICollection<string> Images { get; set; }
        public ICollection<PropertyApiDto> Properties { get; set; }
    }
}
