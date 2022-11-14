using System.Collections.Generic;
using Interface.Dtos;

namespace Interface.DAL;

public interface IPhotoDal
{
    public IList<PhotoDto> GetAllPhotosFromAlbum(int albumId);
    public PhotoDto GetPhotoById(int photoId);
    public void AddPhotoToAlbum(PhotoDto photo, int albumId);
    public void AddPhotosToAlbum(IList<PhotoDto> photos, int albumId);
    public void UpdatePhoto(PhotoDto photo);
    public void DeletePhoto(int photoId);
}