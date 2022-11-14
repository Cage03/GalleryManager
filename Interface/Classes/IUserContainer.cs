using System.Collections.Generic;
using Interface.Dtos;

namespace Interface.Interfaces
{
    public interface IUserContainer 
    {
        public int AddUser(UserDto userDto);
        public bool RemoveUser(int id);
        public bool UpdateUser(UserDto userDto);
        public UserDto GetUser(int id);

        public IList<UserDto> GetAllUsers();
    }
}