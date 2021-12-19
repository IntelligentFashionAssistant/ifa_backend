using System.Collections.Generic;
using application.DTOs;

namespace application.services
{
    public interface IUserService : IService<UserDto, long>
    {
        ICollection<UserDto> SearchUser(UserDto searchObj);
        Task<UserDto> CreateUser(UserDto obj);
        // TODO : login 
    }
}