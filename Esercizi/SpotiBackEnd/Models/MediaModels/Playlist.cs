using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SpotiBackEnd.Models.MediaModels
{
    public class Playlist : Media
    {
        public string Name { get; set; }
        public string SongsId { get; set; }
        public int Rating { get; set; }
        public Playlist()
        {
            
        }
    }
}
