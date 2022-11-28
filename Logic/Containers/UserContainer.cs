using System.Collections.Generic;
using System.Linq;
using Interface.Classes;
using Interface.DAL;
using Interface.Dtos;
using Logic.Classes;

namespace Logic.Containers
{
    public class UserContainer : IUserContainer
    {
        public List<User> Users { get; }
        private readonly IUserDal _userDal;

        public UserContainer(IUserDal userDal)
        {
            Users = new List<User>();
            _userDal = userDal;
        }

        public int AddUser(UserDto userDto)
        {
            Users.Add(new User(userDto));
            _userDal.CreateUser(userDto);
            return 0; //not implemented
        }

        public bool RemoveUser(int id)
        {
            var toBeDeleted = new User();
            foreach (var user in Users.Where(user => user.Id == id))
            {
                toBeDeleted = user;
            }

            Users.Remove(toBeDeleted);
            _userDal.DeleteUser(id);
            return true; //not implemented
        }

        public bool UpdateUser(UserDto userDto)
        {
            var toBeDeleted = new User();
            foreach (var user in Users.Where(user => user.Id == userDto.Id))
            {
                toBeDeleted = user;
            }

            Users.Remove(toBeDeleted);
            Users.Add(new User(userDto));
            _userDal.UpdateUser(userDto);

            return true; //not implemented
        }

        public UserDto GetUser(int id)
        {
            return _userDal.GetUserById(id);
        }
        
        public UserDto GetUserByUsername(string username)
        {
            return _userDal.GetUserByUsername(username);
        }

        public IList<UserDto> GetAllUsers()
        {
            return _userDal.GetAllUsers();
        }
    }
}