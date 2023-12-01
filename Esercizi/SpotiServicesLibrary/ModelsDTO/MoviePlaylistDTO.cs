using SpotiBackEnd.Models.MediaModels;
using SpotiServicesLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiServicesLibrary.ModelsDTO
{
    public class MoviePlaylistDTO : IRating
    {
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
