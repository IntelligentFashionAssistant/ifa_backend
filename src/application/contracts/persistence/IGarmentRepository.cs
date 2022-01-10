using domain.Entitys;

namespace application.persistence
{
    public interface IGarmentRepository : IRepository<Garment, long>
    {
        ICollection<Color> GetColors();
        ICollection<Size> GetSizeByCategory(long categoryId);
    }
}