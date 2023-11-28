using SpotifyClone.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Models
{
    internal class MoviePlaylist : IRating
    {
        private int _rating = 0;
        private Movie[] _movies = new Movie[0];
        
        public int Rating { get { return _rating; } set { _rating = value; } }
        public Movie[] Movies { get { return _movies; } private set { _movies = value; } }
        public string PlaylistName { get; private set; }

        public MoviePlaylist()
        {
            
        }
        public MoviePlaylist(string playlistName)
        {
            PlaylistName = playlistName;
        }
        public void UpdateScore() => _rating = Movies.Select(m => m.Rating).Sum();
        
        public void AddMovie(Movie movie) => Movies = Movies.Append(movie).ToArray();
    }
}
