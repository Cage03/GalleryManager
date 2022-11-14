
using System.Collections.Generic;
using DataAccess.Classes;
using Interface.DAL;
using Interface.Dtos;
using Interface.Interfaces;
using Logic.Classes;

namespace Logic.Containers
{
    public class AlbumContainer : IAlbumContainer
    {
        public IList<Album> Albums { get; set; }
        public readonly IAlbumDal _AlbumDal;

        public AlbumContainer(AlbumDal albumDal)
        {
            Albums = new List<Album>();
            _AlbumDal = albumDal;
            GetAllAlbums();
        }

        public int AddAlbum(AlbumDto albumDto)
        {
            Albums.Add(new Album(albumDto));
            _AlbumDal.AddAlbum(albumDto);
            return 0; //Not Implemented
        }

        public bool RemoveAlbum(AlbumDto albumDto)
        {
            var toBeRemoved = new Album(albumDto);
            foreach (var album in Albums)
            {
                if (album.Id == albumDto.Id)
                {
                    toBeRemoved = album;
                }
            }

            Albums.Remove(toBeRemoved);
            _AlbumDal.DeleteAlbum(albumDto.Id);
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
            _AlbumDal.UpdateAlbum(albumDto);
            return true; //not implemented
        }

        public AlbumDto GetAlbum(int id)
        {
            return _AlbumDal.GetAlbumById(id);
        }
        
        public IList<AlbumDto> GetAllAlbumsByUser(int userId)
        {
            return _AlbumDal.GetAllAlbumsByUser(userId);
        }

        public IList<AlbumDto> GetAllAlbums()
        {
            Albums.Clear();
            foreach (var albumDto in _AlbumDal.GetAllAlbums())
            {
                Albums.Add(new Album(albumDto));
            }
            return _AlbumDal.GetAllAlbums();
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
                    album.AddPhoto(photoDto);
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