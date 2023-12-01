using SpotiBackEnd.Models.MediaModels;
using SpotiServicesLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiServicesLibrary.ModelsDTO
{
    public class SongDTO : IRating
    {
        public string Title {  get; set; }
        public int Rating { get; set; }

        public SongDTO(Song song)
        {
            Title = song.Title;
            Rating = song.Rating;
        }
    }
}
