using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyClone.Models;

namespace SpotifyClone.UserModels
{
    internal sealed class UserListener : User
    {
        private Playlist _favorites;
        private Radio[] _radioFavorites;
        private Artist[] _artists = new Artist[0];
        private Album[] _albums = new Album[0];
        private Song[] _songs = new Song[0];
        private MoviePlaylist[] _moviePlaylists = new MoviePlaylist[0];
        private int _remainingTime = 360000;//100 ore in secondi
        private Movie[] _allMovies = new Movie[0];

        public Playlist Favorites { get; private set; }
        public Radio[] RadioFavorites { get { return _radioFavorites; } }
        public Artist[] Artists { get { return _artists; } }
        public Album[] Albums { get { return _albums; } }
        public MoviePlaylist[] PlaylistMovie { get { return _moviePlaylists; } }
        public Song[] AllSongs { get => _songs; set => _songs  = value; }
        public Movie[] AllMovies { get => _allMovies; set => _allMovies = value; }
        public int RemainingTime {  get { return _remainingTime; } set { _remainingTime = value; } }
        public MembershipTypeEnum MembershipType { get; private set; } 
        public int ListenTime { get; set; }

        public UserListener(int id, string name,MembershipTypeEnum type) : base(id, name)
        {
            _playlists = new Playlist[0];
            _radioFavorites = new Radio[0];
            _favorites = new Playlist(0, "favorites");
            MembershipType = type;

            switch (type)
            {
                case MembershipTypeEnum.FREE:
                    _remainingTime = 360000;//100 ore
                    break;
                case MembershipTypeEnum.PREMIUM:
                    _remainingTime = (int)3.6e+6;//1000 ore
                    break;
                case MembershipTypeEnum.GOLD:
                    _remainingTime = -1;//unlimited
                    break;
                default:
                    _remainingTime = 360000;
                    break;
            }
        }

        public void CreateNewEmptyPlaylist(string playlistName) => 
            _playlists = _playlists.Append(new Playlist(_playlists.Length + 1, playlistName)).ToArray();

        public void CreateNewPlaylist(Playlist playlist)
        {
            _playlists = _playlists.Append(playlist).ToArray();
            GetAllArtists();
            GetAllAlbums();
        }

        public void RemovePlaylist(Playlist playlist)
        {
            _playlists = _playlists.Where(p => p != playlist).ToArray();
            GetAllArtists();
            GetAllAlbums();
        }

        public void AddNewFavorite(Song song)
        {
            _favorites.AddSong(song);
            GetAllArtists();
            GetAllAlbums();
        
        }
        public void RemoveFavorite(Song song)
        {
            _favorites.RemoveSong(song);
            GetAllArtists();
            GetAllAlbums();
        }

        public void AddMovie(Movie movie) => _allMovies = _allMovies.Append(movie).ToArray();
        public void AddMoviePlaylist(MoviePlaylist moviePlaylist) => _moviePlaylists = _moviePlaylists.Append(moviePlaylist).ToArray();

        private void GetAllArtists()
        {
            if (_playlists.Length > 0)
            {
                _artists = _playlists.SelectMany(a => a.Songs).Select(p => p.Artist).Distinct().ToArray();
            }
        }
        private void GetAllAlbums()
        {
            if (_playlists.Length > 0)
            {
                _albums = _playlists.SelectMany(a => a.Songs).Select(a => a.Album).Distinct().ToArray();
            }
        }

        public void UpdateArraySort()
        {
            _albums.ToList().ForEach(a => a.UpdateScore());
            _artists.ToList().ForEach(a => a.UpdateScore());
            _playlists.ToList().ForEach(p => p.UpdateScore());
            _moviePlaylists.ToList().ForEach(p => p.UpdateScore());
            _albums = _albums.OrderByDescending(a => a.Rating).ToArray();
            _artists = _artists.OrderByDescending(a => a.Rating).ToArray();
            _playlists = Playlists.OrderByDescending(p => p.Rating).ToArray();
            _moviePlaylists = _moviePlaylists.OrderByDescending(m => m.Rating).ToArray();
        }
    }
}
