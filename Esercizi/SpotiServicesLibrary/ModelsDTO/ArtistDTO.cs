using SpotiServicesLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using SpotiBackEnd.Models;
using SpotiBackEnd.Models.MediaModels;

namespace SpotiServicesLibrary.ModelsDTO
{
    public class ArtistDTO : Media,IRating
    {
        public string Alias { get; set; }
        public int Rating { get; set; }

        public int[] AlbumsId { get; set; }
        public string Genre { get; set; }

        public ArtistDTO(Artist artist)
        {
            Id = artist.Id;
            Alias = artist.Alias;
            Rating = artist.Rating;
            AlbumsId = artist.AlbumsId.Split('|').Select(s => Int32.Parse(s)).ToArray();
            Genre = artist.Genre;
        }
        public ArtistDTO()
        {
                
        }
    }
}
