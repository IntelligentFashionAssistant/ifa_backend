namespace api.ApiDTOs
{
    public class SizeApiDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int CM { get; set; }
        public long? CategoryId { get; set; }
    }
}
