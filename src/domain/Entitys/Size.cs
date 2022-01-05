namespace domain.Entitys;

public class Size
{
    // small, 70cm
    public long Id { get; set; }
    public string Name { get; set; } 
    public int CM { get; set; } 
    
    public long? CategoryId { get; set; }
    public Category? Category { get; set; }

    public ICollection<Garment>? Garments { get; set; }
    public ICollection<User>? Users { get; set; }

    public Size()
    {
        Garments = new HashSet<Garment>();
        Users = new HashSet<User>();
    }
}
