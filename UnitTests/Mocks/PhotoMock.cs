using Interface.DAL;
using Interface.Dtos;

namespace UnitTests.Mocks;

public class PhotoMock : IPhotoDal
{
    public List<PhotoDto> PhotoDtos;

    public PhotoMock()
    {
        PhotoDtos = new List<PhotoDto>();
        
        PhotoDtos.Add(new PhotoDto()
        {
            Description = "Test Description1",
            Id = 1,
            Href = "Test Href1",
            Name = "Test Name1",
            PhotoType = "Test PhotoType1"
        });
        PhotoDtos.Add(new PhotoDto()
        {
            Description = "Test Description2",
            Id = 2,
            Href = "Test Href2",
            Name = "Test Name2",
            PhotoType = "Test PhotoType2"
        });
        PhotoDtos.Add(new PhotoDto(){
            Description = "Test Description3",
            Id = 3,
            Href = "Test Href3",
            Name = "Test Name3",
            PhotoType = "Test PhotoType3"
        });
    }
    public IList<PhotoDto> GetAllPhotosFromAlbum(int albumId)
    {
        throw new NotImplementedException();
    }

    public PhotoDto GetPhotoById(int photoId)
    {
        return PhotoDtos.Find(x => x.Id == photoId) ?? new PhotoDto();
    }
    
    public void AddPhotoToAlbum(PhotoDto photo, int albumId)
    {
        PhotoDtos.Add(photo);
    }

    public void AddPhotosToAlbum(IList<PhotoDto> photos, int albumId)
    {
        throw new NotImplementedException();
    }

    public void UpdatePhoto(PhotoDto photo)
    {
        var photoToUpdate = PhotoDtos.Find(x => x.Id == photo.Id);
        if (photoToUpdate == null) return;
        photoToUpdate.Description = photo.Description;
        photoToUpdate.Href = photo.Href;
        photoToUpdate.Name = photo.Name;
        photoToUpdate.PhotoType = photo.PhotoType;
    }

    public void DeletePhoto(int photoId)
    {
        var photoToDelete = PhotoDtos.Find(x => x.Id == photoId);
        if (photoToDelete == null) return;
        PhotoDtos.Remove(photoToDelete);
    }
}