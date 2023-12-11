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
        public int ArtistId { get; set; }
        public int[] SongsId { get; set; }
        public int Rating { get; set; }

        public AlbumDTO(Album album)
        {
            Id = album.Id;
            AlbumTitle = album.AlbumName;
            ArtistId = album.ArtistId;
            SongsId = album.SongsId.Split('|').Select(s => int.Parse(s)).ToArray();
            Rating = album.Rating;
        }
        public AlbumDTO()
        {
            
        }
    }
}
