using SpotiServicesLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using SpotiBackEnd.Models.UserModels;
using SpotiBackEnd.Models;

namespace SpotiServicesLibrary.ModelsDTO
{
    public class ArtistDTO : Media,IRating
    {
        public string Alias { get; set; }
        public int Rating { get; set; }

        public AlbumDTO[] Albums { get; set; }
        public string Genre { get; set; }
        public int Id { get; set; }

        public ArtistDTO(Artist artist)
        {
            Alias = artist.Alias;
            Rating = artist.Rating;
            Albums = artist.Albums.Cast<AlbumDTO>().ToArray();
            Genre = artist.Genre;
        }
        public ArtistDTO()
        {
                
        }
    }
}
