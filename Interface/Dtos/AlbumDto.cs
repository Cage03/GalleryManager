using System;
using System.Collections.Generic;

namespace Interface.Dtos
{
    public class AlbumDto
    {
        public List<PhotoDto> Photos = new();
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int Id { get; set; }
    }
}