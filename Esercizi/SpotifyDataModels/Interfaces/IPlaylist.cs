using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyClone.MediaModels;

namespace SpotifyClone.Interfaces
{
    internal interface IPlaylist: IRating
    {
        public void UpdateScore();
    }
}
