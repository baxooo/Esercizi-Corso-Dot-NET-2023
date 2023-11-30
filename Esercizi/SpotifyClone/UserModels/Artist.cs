﻿using SpotifyClone.Interfaces;
using SpotifyClone.MediaModels;
using System.ComponentModel;
using System.Linq;

namespace SpotifyClone.UserModels
{

    internal class Artist : User, IRating
    {
        protected string _alias;
        protected Album[] _albums;
        protected string _genere;
        private int _rating;

        public string Alias { get { return _alias; } }
        public Album[] Albums { get { return _albums; } }
        public string Genere {  get { return _genere; } }
        public int Rating { get { return _rating; } set { _rating = value; } } 

        public Artist(string name, string alias, string genere, int id = 0) : base(id, name)
        {
            _alias = alias;
            _albums = new Album[0];
            _genere = genere;
        }

        public void AddAlbum(Album album)
        {
            _albums = _albums.Append(album).ToArray();
            _rating += album.Rating;
        }

        public void UpdateScore()
        {
            _rating = _albums.Sum(album => album.Rating);
        }
    }
}