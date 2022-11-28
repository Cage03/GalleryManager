using System.Collections.Generic;
using DataAccess.Classes;
using Interface.Classes;
using Interface.DAL;
using Interface.Dtos;
using Logic.Classes;

namespace Logic.Containers
{
    public class AlbumContainer : IAlbumContainer
    {
        public IList<Album> Albums { get; set; }
        public readonly IAlbumDal AlbumDal;

        public AlbumContainer(IAlbumDal albumDal)
        {
            Albums = new List<Album>();
            AlbumDal = albumDal;
            GetAllAlbums();
        }

        public int AddAlbum(AlbumDto albumDto)
        {
            Albums.Add(new Album(albumDto));
            AlbumDal.AddAlbum(albumDto);
            return 0; //Not Implemented
        }

        public bool RemoveAlbum(int id)
        {
            var toBeRemoved = new Album();
            foreach (var album in Albums)
            {
                if (album.Id == id)
                {
                    toBeRemoved = album;
                }
            }

            Albums.Remove(toBeRemoved);
            AlbumDal.DeleteAlbum(id);
            return true; //not implemented
        }

        public bool UpdateAlbum(AlbumDto albumDto)
        {
            var toBeRemoved = new Album();
            foreach (var album in Albums)
            {
                if (album.Id == albumDto.Id)
                {
                    toBeRemoved = album;
                }
            }

            Albums.Remove(toBeRemoved);
            Albums.Add(new Album(albumDto));
            AlbumDal.UpdateAlbum(albumDto);
            return true; //not implemented
        }

        public AlbumDto GetAlbum(int id)
        {
            return AlbumDal.GetAlbumById(id);
        }
        
        public IList<AlbumDto> GetAllAlbumsByUser(int userId)
        {
            return AlbumDal.GetAllAlbumsByUser(userId);
        }

        public IList<AlbumDto> GetAllAlbums()
        {
            Albums.Clear();
            foreach (var albumDto in AlbumDal.GetAllAlbums())
            {
                Albums.Add(new Album(albumDto));
            }
            return AlbumDal.GetAllAlbums();
        }
        
        public IList<PhotoDto> GetPhotosByAlbum(int albumId)
        {
            GetAllAlbums();
            IList<PhotoDto> returnVal = new List<PhotoDto>();
            foreach (var album in Albums)
            {
                if (album.Id == albumId)
                {
                    returnVal = album.GetAllPhotosFromAlbum(albumId);
                }
            }

            return returnVal;
        }

        public PhotoDto GetPhoto(int photoId, int albumId)
        {
            foreach (var album in Albums)
            {
                if(album.Id == albumId)
                {
                    return album.GetPhoto(photoId);
                }
            }

            return new PhotoDto();
        }

        public void AddPhoto(PhotoDto photoDto, int albumId)
        {
            foreach (var album in Albums)
            {
                if (album.Id == albumId)
                {
                    album.AddPhoto(photoDto, albumId);
                }
            }
        }
        
        public void AddPhotosToAlbum(IList<PhotoDto> photoDtos, int albumId)
        {
            foreach (var album in Albums)
            {
                if (album.Id == albumId)
                {
                    album.AddPhotosToAlbum(photoDtos, albumId);
                }
            }
        }

        public void RemovePhoto(PhotoDto photoDto, int albumId)
        {
            foreach (var album in Albums)
            {
                if(album.Id == albumId)
                {
                    album.RemovePhoto(photoDto);
                }
            }
        }

        public void UpdatePhoto(PhotoDto photoDto, int albumId)
        {
            foreach (var album in Albums)
            {
                if(album.Id == albumId)
                {
                    album.UpdatePhoto(photoDto);
                }
            }
        }
    }
}