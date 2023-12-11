using System.ComponentModel;
using System.Linq;

namespace SpotiBackEnd.Models.MediaModels
{

    public class Artist : Media
    {
        public string Alias { get; set; }
        public string AlbumsId { get; set; }
        public string Genre { get; set; }
        public int Rating { get; set; }
        public Artist()
        {
            
        }
    }
}