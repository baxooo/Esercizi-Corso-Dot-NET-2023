
using System.Xml.Linq;

namespace SpotiBackEnd.Models.MediaModels
{
    public class Radio : Media
    {
        public string Name { get; set; }
        public string OnAirPlaylistId { get; set; }
        public int Rating { get; set; }
        public Radio()
        {
            
        }
    }
}