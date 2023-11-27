using SpotifyClone.Interfaces;
using System.ComponentModel;
using System.Linq;

namespace SpotifyClone.UserModels
{
    
    internal class Artist : User,IRating
    {
        protected string _alias;
        protected Album[] _albums;
        protected string _genere;
        private int _score;

        public string Alias { get { return _alias; } }
        public Album[] Albums { get { return _albums; } }
        public string Genere {  get { return _genere; } }
        public int Rating { get { return _score; } } 

        public Artist(string name, string alias, string genere, int id = 0) : base(id, name)
        {
            _alias = alias;
            _albums = new Album[0];
            _genere = genere;
        }

        public void AddAlbum(Album album)
        {
            _albums = _albums.Append(album).ToArray();
            _score += album.Rating;
        }

        public void UpdateAlbumScore()
        {
            _score = _albums.Sum(album => album.Rating);
        }
    }
}