using SpotifyClone.Interfaces;
using SpotifyClone.MediaModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpotifyClone.ModelsDTO
{
    public class PlaylistDTO : IRating
    {
        public int Rating { get; set; }
        public string Name { get; set; }
        public SongDTO[] Songs { get; set; }
    }
}
