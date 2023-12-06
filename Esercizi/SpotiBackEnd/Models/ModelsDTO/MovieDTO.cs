using SpotiBackEnd.Interfaces;
using SpotiBackEnd.Models.MediaModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiBackEnd.Models.ModelsDTO
{
    internal class MovieDTO : IRating
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Rating { get; set; }
        public int[] Resolution { get; set; }
        public MovieDTO(Movie movie)
        {
            Title = movie.Title;
            Rating = movie.Rating;
            Resolution = movie.Resolution;
        }
    }
}
