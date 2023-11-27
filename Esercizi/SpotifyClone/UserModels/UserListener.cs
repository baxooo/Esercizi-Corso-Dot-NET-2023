using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.UserModels
{
    internal sealed class UserListener : User
    {
        private Playlist _favorites;
        private bool _isPremium;
        private Radio[] _radioFavorites;
        private Artist[] _artists = new Artist[0];
        private Album[] _albums = new Album[0];

        public Playlist Favorites { get; private set; }
        public bool IsPremium { get { return _isPremium; } }
        public Radio[] RadioFavorites { get { return _radioFavorites; } }
        public Artist[] Artists { get { return _artists; } }
        public Album[] Albums { get { return _albums; } }

        public UserListener(int id, string name) : base(id, name)
        {
            _playlists = new Playlist[0];
            _radioFavorites = new Radio[0];
            _favorites = new Playlist(0, "favorites");
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
            _artists.ToList().ForEach(a => a.UpdateAlbumScore());
            _playlists.ToList().ForEach(a => a.UpdateScore());
            _albums = _albums.OrderByDescending(a => a.Rating).ToArray();
            _artists = _artists.OrderByDescending(a => a.Rating).ToArray();
            _playlists = Playlists.OrderByDescending(a => a.Rating).ToArray();
        }
    }
}
