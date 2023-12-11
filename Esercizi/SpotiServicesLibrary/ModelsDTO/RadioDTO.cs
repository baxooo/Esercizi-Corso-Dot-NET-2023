using SpotiBackEnd.Models;
using SpotiBackEnd.Models.MediaModels;
using SpotiServicesLibrary.Interfaces;
using System;

namespace SpotiServicesLibrary.ModelsDTO
{
    public class RadioDTO : Media, IRating
    {
        public string Name { get; set; }
        public int OnAirPlaylistId { get; set; }
        public int Rating { get; set; }

        public RadioDTO(Radio radio)
        {
            Name = radio.Name;
            OnAirPlaylistId = int.Parse(radio.OnAirPlaylistId);
            Rating = radio.Rating;
        }
        public RadioDTO()
        {
            
        }
    }
}
