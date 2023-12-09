using SpotiBackEnd.Models;
using SpotiBackEnd.Models.MediaModels;
using SpotiServicesLibrary.Interfaces;
using System;

namespace SpotiServicesLibrary.ModelsDTO
{
    public class SongDTO : Media,IRating
    {
        public string Title {  get; set; }
        public int Rating { get; set; }

        public SongDTO(Song song)
        {
            Title = song.Title;
            Rating = song.Rating;
            Id = song.Id;
        }
        public SongDTO()
        {
            
        }
    }
}
