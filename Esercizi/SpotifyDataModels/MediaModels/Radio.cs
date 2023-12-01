﻿using SpotifyClone.Interfaces;

namespace SpotifyClone.MediaModels
{
    internal class Radio : IRating
    {
        private readonly string _name;
        private Playlist _onAirPlaylist;

        public string Name { get { return _name; } }
        public Playlist OnAirPlaylist { get { return _onAirPlaylist; } }
        public int Rating { get { return _onAirPlaylist.Rating; } set { _onAirPlaylist.Rating = value; } }

        public Radio(string name)
        {
            _name = name;
        }

        public void GetPlaylist()
        {

        }
    }
}