using System.Collections.Generic;
using System.Linq;

namespace SpotiAPI.Models.ModelsDTO
{
    public class ArtistDTO
    {
        public ArtistDTO()
        {
            
        }
        public ArtistDTO(Artist artist)
        {
            Id = artist.Id;
            Alias = artist.Alias;
            Genre = artist.Genre;
            Rating = artist.Rating;
            Albums = artist.Albums.Select(a => new AlbumDTO(a)).ToList();
        }

        public int Id { get; set; }
        public string Alias { get; set; }
        public string Genre { get; set; }
        public int? Rating { get; set; }

        public List<AlbumDTO> Albums { get; set; }
    }
}
