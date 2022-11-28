using Interface.DAL;
using Interface.Dtos;

namespace UnitTests.Mocks;

public class AlbumMock : IAlbumDal
{
    public List<AlbumDto> AlbumDtos;
    public AlbumMock()
    {
        AlbumDtos = new List<AlbumDto>();
        
        AlbumDtos.Add(new AlbumDto
        {
            Id = 1,
            Date = new DateTime(2011,1,1),
            Description = "Description 1",
            Name = "Name 1",
            Photos = new List<PhotoDto>()
            {
                new PhotoDto()
                {
                    Description = "Description 1",
                    Id = 1,
                    Name = "Name 1",
                    Href = "Href 1",
                    PhotoType = "PhotoType 1"
                },
                new PhotoDto()
                {
                    Description = "Description 2",
                    Id = 2,
                    Name = "Name 2",
                    Href = "Href 2",
                    PhotoType = "PhotoType 2"
                },
                new PhotoDto()
                {
                    Description = "Description 3",
                    Id = 3,
                    Name = "Name 3",
                    Href = "Href 3",
                    PhotoType = "PhotoType 3"
                }
            }
        });
        AlbumDtos.Add(new AlbumDto()
        {
            Id = 2,
            Date = new DateTime(2012,2,2),
            Description = "Description 2",
            Name = "Name 2",
            Photos = new List<PhotoDto>()
            {
                new PhotoDto()
                {
                    Description = "Description 4",
                    Id = 4,
                    Name = "Name 4",
                    Href = "Href 4",
                    PhotoType = "PhotoType 4"
                },
                new PhotoDto()
                {
                    Description = "Description 5",
                    Id = 5,
                    Name = "Name 5",
                    Href = "Href 5",
                    PhotoType = "PhotoType 5"
                },
                new PhotoDto()
                {
                    Description = "Description 6",
                    Id = 6,
                    Name = "Name 6",
                    Href = "Href 6",
                    PhotoType = "PhotoType 6"
                }
            }
        });
        AlbumDtos.Add(new AlbumDto()
        {
            Id = 3,
            Date = new DateTime(2013,3,3),
            Description = "Description 3",
            Name = "Name 3",
            Photos = new List<PhotoDto>()
            {
                new PhotoDto()
                {
                    Description = "Description 7",
                    Id = 7,
                    Name = "Name 7",
                    Href = "Href 7",
                    PhotoType = "PhotoType 7"
                },
                new PhotoDto()
                {
                    Description = "Description 8",
                    Id = 8,
                    Name = "Name 8",
                    Href = "Href 8",
                    PhotoType = "PhotoType 8"
                },
                new PhotoDto()
                {
                    Description = "Description 9",
                    Id = 9,
                    Name = "Name 9",
                    Href = "Href 9",
                    PhotoType = "PhotoType 9"
                }
            }
        });
    }
    
    public IList<AlbumDto> GetAllAlbums()
    {
        return AlbumDtos;
    }

    public IList<AlbumDto> GetAllAlbumsByUser(int userId)
    {
        throw new NotImplementedException();
    }

    public AlbumDto GetAlbumById(int id)
    {
        return AlbumDtos.FirstOrDefault(x => x.Id == id) ?? new AlbumDto();
    }

    public void AddAlbum(AlbumDto album)
    {
        AlbumDtos.Add(album);
    }

    public void UpdateAlbum(AlbumDto album)
    {
        var albumToUpdate = AlbumDtos.FirstOrDefault(x => x.Id == album.Id);
        if (albumToUpdate == null) return;
        albumToUpdate.Name = album.Name;
        albumToUpdate.Description = album.Description;
        albumToUpdate.Date = album.Date;
    }

    public void DeleteAlbum(int id)
    {
        var albumToDelete = AlbumDtos.FirstOrDefault(x => x.Id == id);
        if (albumToDelete == null) return;
        AlbumDtos.Remove(albumToDelete);
    }
}