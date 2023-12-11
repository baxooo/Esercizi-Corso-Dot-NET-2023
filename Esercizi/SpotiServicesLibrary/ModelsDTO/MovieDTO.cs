using SpotiBackEnd.Models;
using SpotiBackEnd.Models.MediaModels;
using SpotiServicesLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiServicesLibrary.ModelsDTO
{
    public class MovieDTO : Media , IRating
    {
        public string Title { get; set; }
        public int Rating { get; set; }
        public int[] Resolution { get; set; }
        public MovieDTO(Movie movie)
        {
            Id = movie.Id;
            Title = movie.Title;
            Rating = movie.Rating;
            Resolution = movie.Resolution;
        }
        public MovieDTO() { }   
    }
}
