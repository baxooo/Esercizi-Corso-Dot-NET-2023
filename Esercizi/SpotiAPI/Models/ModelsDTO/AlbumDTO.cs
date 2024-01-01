using System;
using System.Collections.Generic;
using System.Linq;

namespace SpotiAPI.Models.ModelsDTO
{
    public class AlbumDTO
    {
        public AlbumDTO()
        {
            
        }
        public AlbumDTO(Album album)
        {
            Id = album.Id;
            AlbumName = album.AlbumName;
            ReleaseDate = album.ReleaseDate;
            Genre = album.Genre;
            Rating = album.Rating;
            Songs = album.Songs.Select(s => new SongDTO(s)).ToList();
        }

        public int Id { get; set; }
        public string AlbumName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public int? Rating { get; set; }
        public List<SongDTO> Songs { get; set; }
    }
}
