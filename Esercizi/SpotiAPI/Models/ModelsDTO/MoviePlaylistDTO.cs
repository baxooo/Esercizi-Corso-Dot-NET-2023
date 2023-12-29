using System.Collections.Generic;
using System.Linq;

namespace SpotiAPI.Models.ModelsDTO
{
    public class MoviePlaylistDTO
    {
        public MoviePlaylistDTO(MoviePlaylist movie)
        {
            Id = movie.Id;
            Rating = movie.Rating;
            PlaylistName = movie.Name;
            Movies = movie.Movies.ToList();
        }

        public int Id { get; set; }
        public int? Rating { get; set; }
        public string PlaylistName { get; set; }
        public virtual List<Movie> Movies { get; set; }
    }
}
