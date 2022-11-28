using System.Collections.Generic;
using Interface.Dtos;

namespace Interface.Classes
{
    public interface IAlbumContainer
    {
        public int AddAlbum(AlbumDto albumDto);
        public bool RemoveAlbum(int id);
        public bool UpdateAlbum(AlbumDto albumDto);
        public AlbumDto GetAlbum(int id);
        public IList<AlbumDto> GetAllAlbumsByUser(int userId);
        public IList<AlbumDto> GetAllAlbums();
        public IList<PhotoDto> GetPhotosByAlbum(int albumId);
        public PhotoDto GetPhoto(int photoId, int albumId);
        public void AddPhoto(PhotoDto photoDto, int albumId);
        public void AddPhotosToAlbum(IList<PhotoDto> photoDtos, int albumId);
        public void RemovePhoto(PhotoDto photoDto, int albumId);
        public void UpdatePhoto(PhotoDto photoDto, int albumId);
    }
}