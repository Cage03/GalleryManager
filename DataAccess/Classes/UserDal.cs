using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Interface.DAL;
using Interface.Dtos;

namespace DataAccess.Classes
{
    public class UserDal : IUserDal
    {
        private const string ConnectionString =
            "Server=mssqlstud.fhict.local;Database=dbi480282;User Id=dbi480282;Password=01ZX09cv!;";

        public IList<UserDto> GetAllUsers()
        {
            var users = new List<UserDto>();
            
            using var connection = new SqlConnection(ConnectionString);

            try
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM [User]", connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var user = new UserDto
                    {
                        Id = (int)reader["Id"],
                        AccountStatus = (string)reader["AccountStatus"],
                        Password = (string)reader["Password"],
                        Username = (string)reader["Username"]
                    };
                    users.Add(user);
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return users;
        }
        
        public UserDto GetUserById(int id)
        {
            var user = new UserDto();
            
            using var connection = new SqlConnection(ConnectionString);

            try
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM [User] WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    user.Id = (int)reader["Id"];
                    user.AccountStatus = (string)reader["AccountStatus"];
                    user.Password = (string)reader["Password"];
                    user.Username = (string)reader["Username"];
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return user;
        }
        
        public UserDto GetUserByUsername(string username)
        {
            var user = new UserDto();
            
            using var connection = new SqlConnection(ConnectionString);

            try
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM [User] WHERE Username = @Username", connection);
                command.Parameters.AddWithValue("@Username", username);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    user.Id = (int)reader["Id"];
                    user.AccountStatus = (string)reader["AccountStatus"];
                    user.Password = (string)reader["Password"];
                    user.Username = (string)reader["Username"];
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return user;
        }
        
        public void CreateUser(UserDto user)
        {
            using var connection = new SqlConnection(ConnectionString);

            try
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO [User] (Username, Password, AccountStatus) VALUES (@Username, @Password, @AccountStatus)", connection);
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@AccountStatus", user.AccountStatus);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        
        public void UpdateUser(UserDto user)
        {
            using var connection = new SqlConnection(ConnectionString);

            try
            {
                connection.Open();
                var command = new SqlCommand("UPDATE [User] SET Username = @Username, Password = @Password, AccountStatus = @AccountStatus WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", user.Id);
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@AccountStatus", user.AccountStatus);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        
        public void DeleteUser(int id)
        {
            using var connection = new SqlConnection(ConnectionString);

            try
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM [User] WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}