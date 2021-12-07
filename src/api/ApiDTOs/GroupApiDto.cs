namespace api.ApiDTOs
{
    public class GroupApiDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long CategoryId { get; set; }

        public string Category { get; set; }
    }
}
