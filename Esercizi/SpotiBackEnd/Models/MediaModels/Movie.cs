using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiBackEnd.Models.MediaModels
{
    public class Movie 
    {
        public string Title { get; private set; }
        public int Rating { get; private set; }
        public int[] Resolution { get; private set; }

        public Movie(int rating, int[] resolution, string title)
        {
            if (resolution.Length != 2)
            {
                throw new ArgumentException("resolution int[] must be made of 2 elements");
            }
            Title = title;
            Rating = rating;
            Resolution = resolution;
        }
    }
}
