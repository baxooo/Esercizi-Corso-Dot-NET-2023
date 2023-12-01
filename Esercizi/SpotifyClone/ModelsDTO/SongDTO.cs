using SpotifyClone.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.ModelsDTO
{
    public class SongDTO : IRating
    {
        public string Title {  get; set; }
        public int Rating { get; set; }
    }
}
