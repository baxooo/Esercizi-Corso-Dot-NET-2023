using SpotiBackEnd.Interfaces;
using SpotiBackEnd.Models.MediaModels;
using System.Linq;
namespace SpotiBackEnd.Models.ModelsDTO
{
    internal class MoviePlaylistDTO : IRating
    {
        public int Id { get; set; } 
        public int PlaylistId { get; set; }
        public int Rating { get; set; }
        public MovieDTO[] Movies { get; set; }
        public string PlaylistName { get; set; }
        public MoviePlaylistDTO(MoviePlaylist playlist)
        {
            Rating = playlist.Rating;
            Movies = playlist.Movies.Cast<MovieDTO>().ToArray();
            PlaylistName = playlist.PlaylistName;
        }
    }
}
