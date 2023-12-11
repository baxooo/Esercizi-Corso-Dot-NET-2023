using SpotiBackEnd.Models;
using SpotiBackEnd.Models.MediaModels;
using SpotiServicesLibrary.Interfaces;
using System;
using System.Linq;

namespace SpotiServicesLibrary.ModelsDTO
{
    public class MoviePlaylistDTO : Media, IRating
    {
        public int PlaylistId { get; set; }
        public int Rating { get; set; }
        public int[] MoviesId { get; set; }
        public string PlaylistName { get; set; }
        public MoviePlaylistDTO(MoviePlaylist playlist)
        {
            Id = playlist.Id;
            Rating = playlist.Rating;
            MoviesId = playlist.MoviesId;
            PlaylistName = playlist.PlaylistName;
        }
    }
}
