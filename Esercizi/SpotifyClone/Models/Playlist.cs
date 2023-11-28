using SpotifyClone.Interfaces;
using SpotifyClone.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Models
{
    internal class Playlist : IPlaylist
    {
        protected string _name;
        protected Song[] _songs = new Song[0];
        protected int _id;
        private int _rating;
        public string Name { get { return _name; } }
        public Song[] Songs { get { return _songs; } }

        public int PlaylistId { get { return _id; } }
        public int Rating { get { return _rating; } set { _rating = value; } }

        public Playlist(int id, string name)
        {
            _id = id;
            _name = name;
        }

        public void AddSong(Song song)
        {
            _songs = _songs.Append(song).ToArray();
            _rating += song.Rating;
        }

        public void RemoveSong(Song song)
        {
            _songs = _songs.Where(s => s != song).ToArray();
            _rating -= song.Rating;
        }

        public void UpdateScore()
        {
            _rating = _songs.Sum(s => s.Rating);
            _songs = _songs.OrderByDescending(p => p.Rating).ToArray();
        }
    }
}
