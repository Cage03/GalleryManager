using System;
using System.Collections.Generic;
using DataAccess.Classes;
using Interface.DAL;
using Interface.Dtos;

namespace Logic.Classes 
{
    public class Album
    {
        public List<Photo> Photos = new();
        public string Name { get; set;}
        public string Description { get; set;}
        public DateTime Date { get; set;}
        public int Id { get; set;}
        private readonly IPhotoDal _photoDal = new PhotoDal();

        public Album(List<Photo> photos, string name, string description, DateTime date, IPhotoDal photoDal)
        {
            Photos = photos;
            Name = name;
            Description = description;
            Date = date;
            _photoDal = photoDal;
        }

        public Album(AlbumDto albumDto)
        {
            //Convert PhotoDtos to Photo class.
            List<Photo> photos = new();
            foreach (var albumPhotoDto in albumDto.Photos)
            {
                photos.Add(new Photo(albumPhotoDto));
            }

            Photos = photos;
            Name = albumDto.Name;
            Description = albumDto.Description;
            Date = albumDto.Date;
            Id = albumDto.Id;
        }

        public Album(IPhotoDal photoDal)
        {
            _photoDal = photoDal;
        }
        public Album()
        {
            
        }

        public IReadOnlyCollection<Photo> GetAllPhotos()
        {
            return Photos;
        }

        
        public AlbumDto ToDto()
        {
            List<PhotoDto> photoDtos = new();
            foreach (var photo in Photos)
            {
                photoDtos.Add(photo.ToDto());
            }
            
            return new AlbumDto()
            {
                Date = Date,
                Description = Description,
                Id = Id,
                Name = Name,
                Photos = photoDtos
            };
        }

        public void AddPhoto(PhotoDto photoDto, int albumId)
        {
            Photos.Add(new Photo(photoDto));
            _photoDal.AddPhotoToAlbum(photoDto, albumId);
        }
        
        public void AddPhotosToAlbum(IList<PhotoDto> photos, int albumId)
        {
            _photoDal.AddPhotosToAlbum(photos, albumId);
        }

        public void RemovePhoto(PhotoDto photoDto)
        {
            var toBeDeleted = new Photo(); 
            foreach (var photo in Photos)
            {
                if (photo.Id == photoDto.Id)
                {
                    toBeDeleted = photo;
                }
            }

            Photos.Remove(toBeDeleted);
            _photoDal.DeletePhoto(photoDto.Id);
        }

        public void UpdatePhoto(PhotoDto photoDto)
        {
            var toBeDeleted = new Photo(); 
            foreach (var photo in Photos)
            {
                if (photo.Id == photoDto.Id)
                {
                    toBeDeleted = photo;
                }
            }

            Photos.Remove(toBeDeleted);
            Photos.Add(new Photo(photoDto));
            _photoDal.UpdatePhoto(photoDto);
        }

        public IList<PhotoDto> GetAllPhotosFromAlbum(int albumId)
        {
            return _photoDal.GetAllPhotosFromAlbum(albumId);
        }

        public PhotoDto GetPhoto(int id)
        {
            return _photoDal.GetPhotoById(id);
        }
    }
}