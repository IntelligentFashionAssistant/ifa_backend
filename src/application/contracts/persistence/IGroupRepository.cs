using domain.Entitys;

namespace application.persistence
{
    public interface IGroupRepository : IRepository<Group, long>
    {
        ICollection<Group> GetGroupByCategory(long id);
    }
}