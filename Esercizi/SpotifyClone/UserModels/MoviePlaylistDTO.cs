using SpotifyClone.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.UserModels
{
    internal class MoviePlaylistDTO : IRating
    {
        public int Rating { get;  set; }
        public Movie[] Movies { get;  set;  }
        public string PlaylistName { get; set; }
    }
}
