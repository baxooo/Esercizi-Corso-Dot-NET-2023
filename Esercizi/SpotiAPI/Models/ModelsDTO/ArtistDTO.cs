using System.Collections.Generic;
using System.Linq;

namespace SpotiAPI.Models.ModelsDTO
{
    public class ArtistDTO
    {
        public ArtistDTO(Artist artist)
        {
            Id = artist.Id;
            Alias = artist.Alias;
            Genre = artist.Genre;
            Rating = artist.Rating;
            Albums = artist.Albums.ToList();
            Songs = artist.Songs.ToList();
        }

        public int Id { get; set; }
        public string Alias { get; set; }
        public string Genre { get; set; }
        public int? Rating { get; set; }

        public List<Album> Albums { get; set; }
        public List<Song> Songs { get; set; }
    }
}
