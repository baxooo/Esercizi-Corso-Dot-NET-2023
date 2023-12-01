using SpotifyClone.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.ModelsDTO
{
    public class AlbumDTO : IRating
    {
        public string AlbumTitle { get; set; }
        public ArtistDTO Artist { get; set; }
        public SongDTO[] Songs { get; set; }
        public int Rating { get; set; }
    }
}
