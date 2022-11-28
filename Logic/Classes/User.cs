using System;
using Interface.Dtos;

namespace Logic.Classes
{
    public class User 
    {
        public string Username { get; set;}
        public string Password { get; set;}
        public string AccountStatus { get; set;}
        public int Id { get; set;}

        public User(string username, string password, string accountStatus)
        {
            Username = username;
            Password = password;
            AccountStatus = accountStatus;
        }

        public User(UserDto userDto)
        {
            Username = userDto.Username;
            Password = userDto.Password;
            AccountStatus = userDto.AccountStatus;
        }

        public User()
        {
            
        }

        public UserDto ToDto()
        {
            return new UserDto()
            {
                AccountStatus = AccountStatus,
                Id = Id,
                Password = Password,
                Username = Username
            };
        }
    }
}