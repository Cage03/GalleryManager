using System.Data.SqlClient;
using Interface.DAL;
using Interface.Dtos;

namespace DataAccess.Classes
{
    public class AlbumDal : IAlbumDal
    {
        private const string ConnectionString =
            "Server=mssqlstud.fhict.local;Database=dbi480282;User Id=dbi480282;Password=01ZX09cv!;";


        public IList<AlbumDto> GetAllAlbums()
        {
            var albums = new List<AlbumDto>();
            var connection = new SqlConnection(ConnectionString);
            try
            {
                using (connection)
                {
                    connection.Open();
                    var command = new SqlCommand("SELECT * FROM Album", connection);
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var album = new AlbumDto
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            Description = (string)reader["Description"]
                        };
                        albums.Add(album);
                    }
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

            return albums;
        }
        
        public IList<AlbumDto> GetAllAlbumsByUser(int userId)
        {
            var albums = new List<AlbumDto>();
            var connection = new SqlConnection(ConnectionString);
            try
            {
                using (connection)
                {
                    connection.Open();
                    var command = new SqlCommand("SELECT * FROM Album WHERE UserId = @userId", connection);
                    command.Parameters.AddWithValue("@userId", userId);
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var album = new AlbumDto
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            Description = (string)reader["Description"]
                        };
                        albums.Add(album);
                    }
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

            return albums;
        }

        public AlbumDto GetAlbumById(int id)
        {
            var album = new AlbumDto();
            var connection = new SqlConnection(ConnectionString);
            try
            {
                using (connection)
                {
                    connection.Open();
                    var command = new SqlCommand("SELECT * FROM Album WHERE Id = @Id", connection);
                    command.Parameters.AddWithValue("@Id", id);
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        album.Id = (int)reader["Id"];
                        album.Name = (string)reader["Name"];
                        album.Description = (string)reader["Description"];
                    }
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

            return album;
        }
        
        public void AddAlbum(AlbumDto album)
        {
            var connection = new SqlConnection(ConnectionString);
            try
            {
                using (connection)
                {
                    connection.Open();
                    var command = new SqlCommand("INSERT INTO Album (Name, Description) VALUES (@Name, @Description)", connection);
                    command.Parameters.AddWithValue("@Name", album.Name);
                    command.Parameters.AddWithValue("@Description", album.Description);
                    command.ExecuteNonQuery();
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
        }
        
        public void UpdateAlbum(AlbumDto album)
        {
            var connection = new SqlConnection(ConnectionString);
            try
            {
                using (connection)
                {
                    connection.Open();
                    var command = new SqlCommand("UPDATE Album SET Name = @Name, Description = @Description WHERE Id = @Id", connection);
                    command.Parameters.AddWithValue("@Id", album.Id);
                    command.Parameters.AddWithValue("@Name", album.Name);
                    command.Parameters.AddWithValue("@Description", album.Description);
                    command.ExecuteNonQuery();
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
        }
        
        public void DeleteAlbum(int id)
        {
            var connection = new SqlConnection(ConnectionString);
            try
            {
                using (connection)
                {
                    connection.Open();
                    var command = new SqlCommand("DELETE FROM Album WHERE Id = @Id", connection);
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
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
        }
    }
}