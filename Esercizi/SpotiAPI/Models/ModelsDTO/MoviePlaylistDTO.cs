using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;

namespace SpotiAPI.Models.ModelsDTO
{
    public class MoviePlaylistDTO
    {
        public MoviePlaylistDTO()
        {
            
        }
        public MoviePlaylistDTO(MoviePlaylist movie)
        {
            Id = movie.Id;
            Rating = movie.Rating;
            PlaylistName = movie.Name;
            Movies = movie.Movies.Select(m => new MovieDTO(m)).ToList();
        }

        public int Id { get; set; }
        public int Rating { get; set; }
        public string PlaylistName { get; set; }
        public virtual List<MovieDTO> Movies { get; set; }
    }
}
