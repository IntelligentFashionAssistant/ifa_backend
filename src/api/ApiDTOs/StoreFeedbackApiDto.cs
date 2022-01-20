namespace api.ApiDTOs
{
    public class StoreFeedbackApiDto
    {
        public long Id { get; set; }
        public string? Header { get; set; }
        public string? Body { get; set; }
        public int Rate { get; set; }
        public long StoreId { get; set; }
        public string? UserName { get; set; }
        public string? UserImage { get; set; }
    }
}
