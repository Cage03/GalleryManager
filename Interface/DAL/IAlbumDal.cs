using System.Collections.Generic;
using Interface.Dtos;

namespace Interface.DAL;

public interface IAlbumDal
{
    public IList<AlbumDto> GetAllAlbums();
    public IList<AlbumDto> GetAllAlbumsByUser(int userId);
    public AlbumDto GetAlbumById(int id);
    public void AddAlbum(AlbumDto album);
    public void UpdateAlbum(AlbumDto album);
    public void DeleteAlbum(int id);
}