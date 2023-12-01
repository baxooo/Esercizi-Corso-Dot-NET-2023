using System.ComponentModel;
using System.Linq;
using SpotiBackEnd.Models.MediaModels;

namespace SpotiBackEnd.Models.UserModels
{

    public class Artist 
    {
        public string Alias { get; set; }
        public Album[] Albums { get; set; }
        public string Genre { get; set; }
        public int Rating { get; set; }
    }
}