using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiBackEnd.Models.MediaModels
{
    public class MoviePlaylist
    {
        public int Rating { get;  set; }
        public Movie[] Movies { get; set; }
        public string PlaylistName { get; set; }
    }
}
