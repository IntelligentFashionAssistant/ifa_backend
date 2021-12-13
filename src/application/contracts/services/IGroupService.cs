using application.DTOs;

namespace application.services
{
    public interface IGroupService : IService<GroupDto, long>
    {
        ICollection<GroupDto> GetGroupByCategory(long id);
    }
}