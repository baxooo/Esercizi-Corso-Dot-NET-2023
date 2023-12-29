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
        }

        public int Id { get; set; }
        public string Alias { get; set; }
        public string Genre { get; set; }
        public int? Rating { get; set; }

        public List<Album> Albums { get; set; }
    }
}
