using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.UserModels
{
    internal sealed class UserListener : User
    {
        private Playlist _favorites = new Playlist("favorites");
        private bool _isPremium;
        private Radio[] _radioFavorites;
        private Artist[] _artists = new Artist[0];

        public Playlist Favorites { get; private set; }
        public bool IsPremium { get { return _isPremium; } }
        public Radio[] RadioFavorites { get { return _radioFavorites; } }
        public Artist[] Artists { get { return _artists; } }

        public UserListener(int id, string name) : base(id, name)
        {
            _playlists = new Playlist[0];
        }

        public void CreateNewEmptyPlaylist(string playlistName) => _playlists = _playlists.Append(new Playlist(playlistName)).ToArray();

        public void CreateNewPlaylist(Playlist playlist)
        {
            _playlists = _playlists.Append(playlist).ToArray();
            GetAllArtists();
        }

        public void RemovePlaylist(Playlist playlist)
        {
            _playlists = _playlists.Where(p => p != playlist).ToArray();
            GetAllArtists();
        }

        public void AddNewFavorite(Song song) => _favorites.AddSong(song);
        public void RemoveFavorite(Song song) => _favorites.RemoveSong(song);

        private void GetAllArtists()
        {
            if (Playlists.Length > 0)
            {
                _artists = _playlists.SelectMany(s => s.Songs).Select(p => p.Artist).Distinct().ToArray();
            }
        }
    }
}
