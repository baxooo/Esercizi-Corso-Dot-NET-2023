using SpotiBackEnd.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiBackEnd.Models.MediaModels
{
    public class Movie : Media, IRating
    {
        public string Title { get; set; }
        public int Rating { get; set; }
        public int[] Resolution { get; set; }
        public Movie()
        {
            
        }
    }
}
