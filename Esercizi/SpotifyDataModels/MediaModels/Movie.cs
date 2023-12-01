using SpotifyClone.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.MediaModels
{
    public class Movie : IRating
    {
        private int _rating;
        private int[] _resolution = new int[2];
        private string _title;

        public string Title { get { return _title; } }
        public int Rating { get { return _rating; } set { _rating = value; } }
        public int[] Resolution { get { return _resolution; } }

        public Movie(int rating, int[] resolution, string title)
        {
            if (resolution.Length != 2)
            {
                throw new ArgumentException("resolution int[] must be made of 2 elements");
            }
            _title = title;
            _rating = rating;
            _resolution = resolution;
        }
    }
}
