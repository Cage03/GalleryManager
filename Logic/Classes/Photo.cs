using System;
using Interface.Dtos;
using Interface.Interfaces;

namespace Logic.Classes
{
    public class Photo
    {
        public string Name { get; set;}
        public string Href { get; set;}
        public string Description { get; set;}
        public string PhotoType { get; set;}
        public int Id { get; set;}

        public Photo(string name, string href, string description, string photoType)
        {
            Name = name;
            Href = href;
            Description = description;
            PhotoType = photoType;
        }

        public Photo(PhotoDto photoDto)
        {
            Name = photoDto.Name;
            Href = photoDto.Href;
            Description = photoDto.Description;
            PhotoType = photoDto.PhotoType;
        }

        public Photo()
        {
            
        }

        public PhotoDto ToDto()
        {
            return new PhotoDto()
            {
                Description = Description,
                Href = Href,
                Id = Id,
                Name = Name,
                PhotoType = PhotoType
            };
        }
    }
}