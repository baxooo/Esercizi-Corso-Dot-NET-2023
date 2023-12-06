using System;
using System.Collections.Generic;
using System.Linq;
using SpotiBackEnd.Interfaces;
using SpotiBackEnd.Models.UserModels;

namespace SpotiBackEnd.Models.ModelsDTO
{
    internal class ArtistDTO : IRating
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
    }
}
