using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone
{
    internal class Playlist : IPlaylist
    {
        protected string _name;
        protected Song[] _songs;

        public string Name { get { return _name; } }
        public Song[] Songs { get { return _songs; } }

        public Playlist(string name)
        {
            _name = name;   
            _songs = new Song[0];
        }

        public void AddSong(Song song)
        {
            _songs = _songs.Append(song).ToArray();
        }

        public void RemoveSong(Song song)
        {
            _songs.Where(s => s != song).ToArray();
        }
    }
}
