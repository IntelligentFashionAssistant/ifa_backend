using System.Collections.Generic;
using application.DTOs;

namespace application.services
{
    // UserServices uses UserManager from Identity Framework 
    // this is why there is no UserRepository
    public class UserService : IUserService
    {
        public UserDto GetById(long id)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<UserDto> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public UserDto Create(UserDto obj)
        {
            throw new System.NotImplementedException();
        }

        public UserDto Edit(UserDto obj)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteById(long id)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<UserDto> SearchUser(UserDto searchObj)
        {
            throw new System.NotImplementedException();
        }
    }
}