namespace api.ApiDTOs
{
    public class GroupApiDto
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ICollection<long>? Categorys { get; set; }
        public ICollection<string>? CategorysNames { get; set; }
        public int? NumberOfPropriety { get; set; } = 0;
        public ICollection<PropertyApiDto>? PropertysInsidGroup { get; set; }
    }
}
