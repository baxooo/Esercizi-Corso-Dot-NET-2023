
using System.Xml.Linq;

namespace SpotiBackEnd.Models.MediaModels
{
    public class Radio
    {
        public string Name { get; set; }
        public Playlist OnAirPlaylist { get; set; }
        public int Rating { get; set; }
    }
}