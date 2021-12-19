namespace ifa_front.Models
{
    public class Garment
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Brand { get; set; }
        public decimal Price { get; set; }
        public long StoreId { get; set; }
        public long CategoryId { get; set; }
        public ICollection<Category> Categorys { get; set; }
        public ICollection<string>? Colors { get; set; }
        //public ICollection<string> Images { get; set; }
        public ICollection<Group> Groups { get; set; }
        public ICollection<int>? PropertyIds { get; set; }
        public IFormFile? Photo { get; set; }
        public string PhotoName { get; set; }
        public Garment()
        {
            PropertyIds = new HashSet<int>();
        }
       
    }

  
}
