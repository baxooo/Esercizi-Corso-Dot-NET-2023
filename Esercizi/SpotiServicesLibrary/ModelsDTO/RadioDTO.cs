using SpotiBackEnd.Models.MediaModels;
using SpotiServicesLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpotiServicesLibrary.ModelsDTO
{
    public class RadioDTO : IRating
    {
        public string Name { get; set; }
        public PlaylistDTO OnAirPlaylist { get; set; }
        public int Rating { get { return OnAirPlaylist.Rating; } set { OnAirPlaylist.Rating = value; } }

        public RadioDTO(Radio radio)
        {
            Name = radio.Name;
            OnAirPlaylist = new PlaylistDTO(radio.OnAirPlaylist);
            Rating = radio.Rating;
        }
    }
}
