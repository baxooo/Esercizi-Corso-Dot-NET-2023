using System.Collections.Generic;
using System.Linq;

namespace SpotiAPI.Models.ModelsDTO
{
    public class AlbumDTO
    {
        public AlbumDTO(Album album)
        {
            Id = album.Id;
            AlbumName = album.AlbumName;
            ReleaseDate = album.ReleaseDate;
            Genre = album.Genre;
            Rating = album.Rating;
            Artist = album.Artist;
            Songs = album.Songs.ToList();
        }

        public int Id { get; set; }
        public string AlbumName { get; set; }
        public string ReleaseDate { get; set; }
        public string Genre { get; set; }
        public int? Rating { get; set; }
        public Artist Artist { get; set; }
        public List<Song> Songs { get; set; }
    }

}
