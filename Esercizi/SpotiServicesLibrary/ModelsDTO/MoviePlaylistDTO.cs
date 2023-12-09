using SpotiBackEnd.Models;
using SpotiBackEnd.Models.MediaModels;
using SpotiServicesLibrary.Interfaces;
using System;
using System.Linq;

namespace SpotiServicesLibrary.ModelsDTO
{
    public class MoviePlaylistDTO : Media, IRating
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
