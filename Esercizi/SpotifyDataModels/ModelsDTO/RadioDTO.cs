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
    public class RadioDTO : IRating
    {
        public string Name { get; set; }
        public PlaylistDTO OnAirPlaylist { get; set; }
        public int Rating { get { return OnAirPlaylist.Rating; } set { OnAirPlaylist.Rating = value; } }
    }
}
