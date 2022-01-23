using domain.Entitys;

namespace application.persistence
{
    public interface IGarmentRepository : IRepository<Garment, long>
    {
        ICollection<Color> GetColors();
        ICollection<Size> GetSizeByCategory(long categoryId);
        ICollection<Garment> GetGarmentFavoriteToUser(long userId);
        void RemoveUser(User user, long garmentId);
        void AddUser(User user, long garmentId);
        bool UserExists(User user, long garmentId);
        Garment GetUserById(long id);
    }
}