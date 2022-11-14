using System.Collections.Generic;
using Interface.Dtos;

namespace Interface.DAL;

public interface IUserDal
{
    public IList<UserDto> GetAllUsers();
    public UserDto GetUserById(int id);
    public UserDto GetUserByUsername(string username);
    public void CreateUser(UserDto user);
    public void UpdateUser(UserDto user);
    public void DeleteUser(int id);
}