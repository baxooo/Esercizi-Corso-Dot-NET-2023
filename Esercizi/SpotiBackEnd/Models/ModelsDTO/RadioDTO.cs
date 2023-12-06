using SpotiBackEnd.Models.MediaModels;
using SpotiBackEnd.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpotiBackEnd.Models.ModelsDTO
{
    internal class RadioDTO : IRating
    {
        public int Id { get; set; }
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
