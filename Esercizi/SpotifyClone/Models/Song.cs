using SpotifyClone.Interfaces;
using SpotifyClone.UserModels;
using SpotifyClone.Models;

namespace SpotifyClone
{
    internal class Song : IRating
    {
        protected int _id;
        protected string _title;
        protected Artist _artist;
        protected Album _album;
        protected string _releaseDate;
        protected int _duration;
        protected string _genre;
        protected int _rating;
        protected int? _playlistId;

        public int Id { get { return _id; } set { _id = value; } }
        public string Title { get { return _title; } set { _title = value; } }
        public Artist Artist { get { return _artist; } set { _artist = value; } }
        public Album Album { get {  return _album; } set { _album = value; } }
        public string ReleaseDate {  get { return _releaseDate; } set { _releaseDate = value; } }
        public int Duration { get {  return _duration; } set { _duration = value; } }
        public string Genre { get { return _genre; } set { _genre = value; } }
        public int Rating { get { return _rating; } set { _rating = value; } }
        public int? PlaylistId { get { return _playlistId; } }

        public Song(int id,string title,Artist artist,Album album, int duration,int rating,int playlistId)
        {
            _id = id;
            _album = album;
            _title = title;
            _artist = artist;
            _releaseDate = album.ReleaseDate;
            _duration = duration;
            _genre = artist.Genere;
            _rating = rating;
            _playlistId = playlistId;
        }
        public Song()
        {
            
        }
    }
}