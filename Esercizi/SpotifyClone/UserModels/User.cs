using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyClone.MediaModels;

namespace SpotifyClone.UserModels
{
    internal abstract class User
    {
        protected int _id;
        protected string _name;
        protected Playlist[] _playlists;

        public int Id { get { return _id; } private set { } }
        public string Name { get { return _name; } }
        public Playlist[] Playlists { get { return _playlists; } }

        public User(int id, string name)
        {
            _name = name;
            _id = id;
        }
    }
}
