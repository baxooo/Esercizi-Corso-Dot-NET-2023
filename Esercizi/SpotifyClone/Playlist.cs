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
        protected Song[] _songs = new Song[0];
        protected int _id;

        public string Name { get { return _name; } }
        public Song[] Songs { get { return _songs; } }
        public int PlaylistId { get { return _id; } }

        public Playlist(int id,string name)
        {
            _id = id;
            _name = name;   
        }
        public Playlist()
        {
            
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
