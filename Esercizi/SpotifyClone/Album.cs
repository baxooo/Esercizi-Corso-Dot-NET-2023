using SpotifyClone.UserModels;

namespace SpotifyClone
{
    internal class Album
    {
        private string _albumName;
        private Artist _artist;
        private Song[] _songs;

        public string AlbumName { get { return _albumName; } }
        public Artist Artist { get { return _artist; } }
        public Song[] Songs {  get { return _songs; } }
        public Album(string albumName, Artist artist, Song[] songs)
        {
            _albumName = albumName;
            _artist = artist;
            _songs = songs;
        }
    }
}