using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Interface.DAL;
using Interface.Dtos;

namespace DataAccess.Classes;

public class PhotoDal : IPhotoDal
{
    private const string ConnectionString =
        "Server=mssqlstud.fhict.local;Database=dbi480282;User Id=dbi480282;Password=01ZX09cv!;";

    public IList<PhotoDto> GetAllPhotosFromAlbum(int albumId)
    {
        var photos = new List<PhotoDto>();

        using var connection = new SqlConnection(ConnectionString);

        try
        {
            using (connection)
            {
                connection.Open();

                var command = new SqlCommand("SELECT * FROM Photo WHERE AlbumId = @albumId", connection);
                command.Parameters.AddWithValue("@albumId", albumId);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var photo = new PhotoDto
                    {
                        Id = (int)reader["Id"],
                        Description = (string)reader["Description"],
                        Href = (string)reader["Href"],
                        Name = (string)reader["Name"],
                        PhotoType = (string)reader["PhotoType"]
                    };

                    photos.Add(photo);
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
        return photos;
    }
    
    public PhotoDto GetPhotoById(int photoId)
    {
        var photo = new PhotoDto();

        using var connection = new SqlConnection(ConnectionString);

        try
        {
            using (connection)
            {
                connection.Open();

                var command = new SqlCommand("SELECT * FROM Photo WHERE Id = @photoId", connection);
                command.Parameters.AddWithValue("@photoId", photoId);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    photo.Id = (int)reader["Id"];
                    photo.Description = (string)reader["Description"];
                    photo.Href = (string)reader["Href"];
                    photo.Name = (string)reader["Name"];
                    photo.PhotoType = (string)reader["PhotoType"];
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
        return photo;
    }

    public void AddPhotosToAlbum(IList<PhotoDto> photos, int albumId)
    {
        using var connection = new SqlConnection(ConnectionString);

        try
        {
            using (connection)
            {
                connection.Open();

                var command =
                    new SqlCommand(
                        "INSERT INTO Photo (Name, Description, Href, PhotoType, AlbumId) VALUES (@name, @description, @href, @photoType, @albumId)",
                        connection);
                foreach (var photo in photos)
                {
                    command.Parameters.AddWithValue("@name", photo.Name);
                    command.Parameters.AddWithValue("@description", photo.Description);
                    command.Parameters.AddWithValue("@href", photo.Href);
                    command.Parameters.AddWithValue("@photoType", photo.PhotoType);
                    command.Parameters.AddWithValue("@albumId", albumId);

                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
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
    }

    public void AddPhotoToAlbum(PhotoDto photo, int albumId)
    {
        using var connection = new SqlConnection(ConnectionString);

        try
        {
            using (connection)
            {
                connection.Open();

                var command = new SqlCommand("INSERT INTO Photo (Name, Description, Href, PhotoType, AlbumId) VALUES (@name, @description, @href, @photoType, @albumId)", connection);
                command.Parameters.AddWithValue("@name", photo.Name);
                command.Parameters.AddWithValue("@description", photo.Description);
                command.Parameters.AddWithValue("@href", photo.Href);
                command.Parameters.AddWithValue("@photoType", photo.PhotoType);
                command.Parameters.AddWithValue("@albumId", albumId);

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
    
    public void DeletePhoto(int photoId)
    {
        using var connection = new SqlConnection(ConnectionString);

        try
        {
            using (connection)
            {
                connection.Open();

                var command = new SqlCommand("DELETE FROM Photo WHERE Id = @photoId", connection);
                command.Parameters.AddWithValue("@photoId", photoId);

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
    
    public void UpdatePhoto(PhotoDto photo)
    {
        using var connection = new SqlConnection(ConnectionString);

        try
        {
            using (connection)
            {
                connection.Open();

                var command = new SqlCommand("UPDATE Photo SET Name = @name, Description = @description, Href = @href, PhotoType = @photoType WHERE Id = @photoId", connection);
                command.Parameters.AddWithValue("@name", photo.Name);
                command.Parameters.AddWithValue("@description", photo.Description);
                command.Parameters.AddWithValue("@href", photo.Href);
                command.Parameters.AddWithValue("@photoType", photo.PhotoType);
                command.Parameters.AddWithValue("@photoId", photo.Id);

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