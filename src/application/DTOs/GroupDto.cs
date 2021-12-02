namespace application.DTOs
{
    public class GroupDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<string> Propertys { get; set; }
    }
}