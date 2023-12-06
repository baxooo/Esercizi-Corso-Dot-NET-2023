using SpotiBackEnd.Interfaces;
using SpotiBackEnd.Models.MediaModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiBackEnd.Models.ModelsDTO
{
    internal class AlbumDTO : IRating
    {
        public string AlbumTitle { get; set; }
        public ArtistDTO Artist { get; set; }
        public SongDTO[] Songs { get; set; }
        public int Rating { get; set; }
        public int Id { get; set; }

        public AlbumDTO(Album album)
        {
            AlbumTitle = album.AlbumName;
            Artist = new ArtistDTO(album.Artist);
            Songs = album.Songs.Cast<SongDTO>().ToArray();
            Rating = album.Rating;
        }
    }
}
