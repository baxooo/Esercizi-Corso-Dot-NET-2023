using SpotiBackEnd.Models;
using SpotiBackEnd.Models.MediaModels;
using SpotiServicesLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiServicesLibrary.ModelsDTO
{
    public class AlbumDTO : Media , IRating
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
        public AlbumDTO()
        {
            
        }
    }
}
