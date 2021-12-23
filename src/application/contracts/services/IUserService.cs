using System.Collections.Generic;
using application.DTOs;

namespace application.services
{
    public interface IUserService : IService<UserDto, long>
    {
        ICollection<UserDto> SearchUser(UserDto searchObj);
        Task<UserDto> CreateUser(UserDto obj);
        Task<UserDto> EditUser(UserDto obj);
        Task<UserDto> GetUserById(long id);
        Task DeleteUserById(long id);
        // TODO : login 
    }
}