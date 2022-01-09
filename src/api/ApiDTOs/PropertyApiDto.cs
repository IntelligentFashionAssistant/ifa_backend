namespace api.ApiDTOs
{
    public class PropertyApiDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long GroupId { get; set; }
        public string Group { get; set; }
    }
}
