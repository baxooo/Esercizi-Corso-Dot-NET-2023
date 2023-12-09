using SpotiBackEnd.Models;
using SpotiBackEnd.Models.MediaModels;
using SpotiServicesLibrary.Interfaces;
using System;

namespace SpotiServicesLibrary.ModelsDTO
{
    public class RadioDTO : Media, IRating
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
        public RadioDTO()
        {
            
        }
    }
}
