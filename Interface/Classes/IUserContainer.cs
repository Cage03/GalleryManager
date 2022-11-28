using System.Collections.Generic;
using Interface.Dtos;

namespace Interface.Classes
{
    public interface IUserContainer 
    {
        public int AddUser(UserDto userDto);
        public bool RemoveUser(int id);
        public bool UpdateUser(UserDto userDto);
        public UserDto GetUser(int id);
        public UserDto GetUserByUsername(string username);
        public IList<UserDto> GetAllUsers();
    }
}