using SpotifyClone.Interfaces;
using SpotifyClone.UserModels;
using System.Linq;

namespace SpotifyClone
{
    internal class Album : IPlaylist,IRating
    {
        private string _albumName;
        private Artist _artist;
        private Song[] _songs;
        private string _releaseDate;
        private string _genere;
        private int _rating;

        public string AlbumName { get { return _albumName; } }
        public Artist Artist { get { return _artist; } }
        public Song[] Songs {  get { return _songs; } }
        public string ReleaseDate { get { return _releaseDate; } }
        public string Genere { get { return _genere; } }
        public int Rating { get { return _rating; } }
        public Album(string albumName, Artist artist, Song[] songs, string releaseDate)
        {
            _albumName = albumName;
            _artist = artist;
            _songs = songs;
            _releaseDate = releaseDate;
            _genere = artist.Genere;
        }
        public void AddSongs(Song[] songs)
        {
            _songs = songs;
            _rating += songs.Sum(p => p.Rating);
            _songs = _songs.OrderByDescending(x => x.Rating).ToArray();
        }

        public void UpdateScore()
        {
            _songs = _songs.OrderByDescending(p => p.Rating).ToArray();
        }
    }
}