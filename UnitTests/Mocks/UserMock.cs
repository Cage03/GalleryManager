using Interface.DAL;
using Interface.Dtos;

namespace UnitTests.Mocks;

public class UserMock : IUserDal
{
    public List<UserDto> UserDtos;
    public UserMock()
    {
        UserDtos = new List<UserDto>()
        {
            new UserDto()
            {
                AccountStatus = "Admin",
                Id = 1,
                Password = "Password1",
                Username = "Username1"
            },
            new UserDto()
            {
                AccountStatus = "Standard",
                Id = 2,
                Password = "Password2",
                Username = "Username2"
            },
            new UserDto()
            {
                AccountStatus = "Standard",
                Id = 3,
                Password = "Password3",
                Username = "Username3"
            }
        };
        }
    
    public IList<UserDto> GetAllUsers()
    {
        return UserDtos;
    }

    public UserDto GetUserById(int id)
    {
        return UserDtos.FirstOrDefault(x => x.Id == id) ?? new UserDto();
    }

    public UserDto GetUserByUsername(string username)
    {
        return UserDtos.FirstOrDefault(x => x.Username == username) ?? new UserDto();
    }

    public void CreateUser(UserDto user)
    {
        UserDtos.Add(user);
    }

    public void UpdateUser(UserDto user)
    {
        var userToUpdate = UserDtos.FirstOrDefault(x => x.Id == user.Id);
        if (userToUpdate == null) return;
        userToUpdate.Username = user.Username;
        userToUpdate.Password = user.Password;
        userToUpdate.AccountStatus = user.AccountStatus;
    }

    public void DeleteUser(int id)
    {
        var userToDelete = UserDtos.FirstOrDefault(x => x.Id == id);
        if (userToDelete != null)
        {
            UserDtos.Remove(userToDelete);
        }
    }
}