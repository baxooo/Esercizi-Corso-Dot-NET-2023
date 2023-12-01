using SpotifyClone.Interfaces;
using SpotifyClone.MediaModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.ModelsDTO
{
    public class ArtistDTO : IRating
    {
        public string Alias { get; set; }
        public int Rating { get; set; }

        public AlbumDTO[] Albums { get; set; }
        public string Genere { get; set; }
    }
}
