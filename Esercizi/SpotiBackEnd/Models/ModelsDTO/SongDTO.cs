using SpotiBackEnd.Interfaces;
using SpotiBackEnd.Models.MediaModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiBackEnd.Models.ModelsDTO
{
    internal class SongDTO : Media , IRating
    {
        public string Title {  get; set; }
        public int Rating { get; set; }

        public SongDTO(Song song)
        {
            Title = song.Title;
            Rating = song.Rating;
            Id = song.Id;
        }
    }
}
