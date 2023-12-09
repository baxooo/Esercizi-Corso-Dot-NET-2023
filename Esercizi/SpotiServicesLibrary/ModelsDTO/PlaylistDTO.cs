using SpotiBackEnd.Models;
using SpotiBackEnd.Models.MediaModels;
using SpotiServicesLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpotiServicesLibrary.ModelsDTO
{
    public class PlaylistDTO : Media, IRating
    {
        public int PlaylistId { get; set; }
        public int Rating { get; set; }
        public string Name { get; set; }
        public SongDTO[] Songs { get; set; }

        public PlaylistDTO(Playlist playlist)
        {
            Rating = playlist.Rating;
            Name = playlist.Name;
            Songs = playlist.Songs.Cast<SongDTO>().ToArray();
        }

        public PlaylistDTO()
        {
                
        }
    }
}
