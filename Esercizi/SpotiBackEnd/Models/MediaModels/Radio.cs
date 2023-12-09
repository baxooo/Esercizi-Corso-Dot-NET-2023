
using System.Xml.Linq;

namespace SpotiBackEnd.Models.MediaModels
{
    public class Radio : Media
    {
        public string Name { get; set; }
        public Playlist OnAirPlaylist { get; set; }
        public int Rating { get; set; }
    }
}