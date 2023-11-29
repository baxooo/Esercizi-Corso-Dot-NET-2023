using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Interfaces
{
    internal interface IMoviePlaylist : IPlaylist
    {
        Movie[] Movies { get; set; }
    }
}
