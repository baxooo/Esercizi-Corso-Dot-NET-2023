using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiBackEnd.Models.MediaModels
{
    public class MoviePlaylist : Media
    {
        public int Rating { get;  set; }
        public int[] MoviesId { get; set; }
        public string PlaylistName { get; set; }
        public MoviePlaylist()
        {
            
        }
    }
}
