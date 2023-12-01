using SpotifyClone.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.ModelsDTO
{
    public class MovieDTO : IRating
    {
        public string Title { get; set; }
        public int Rating { get; set; }
        public int[] Resolution { get; set; }
    }
}
