using SpotifyClone.UserModels;

namespace SpotifyClone
{
    internal class Song
    {
        protected string _title;
        protected Artist _artist;
        protected Album _album;
        protected string _releaseDate;
        protected int _duration;

        public string Title { get { return _title; } }
        public Artist Artist { get { return _artist; } }
        public Album Album { get {  return _album; } }
        public string ReleaseDate {  get { return _releaseDate; } }
        public int Duration { get {  return _duration; } }

        public Song(string title,Artist artist,Album album, int duration)
        {
             _album = album;
            _title = title;
            _artist = artist;
            _releaseDate = album.ReleaseDate;
            _duration = duration;
        }
    }
}