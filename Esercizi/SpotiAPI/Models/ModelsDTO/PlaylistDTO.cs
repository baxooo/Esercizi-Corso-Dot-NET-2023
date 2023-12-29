using System.Collections.Generic;
using System.Linq;

namespace SpotiAPI.Models.ModelsDTO
{
    public class PlaylistDTO
    {
        public PlaylistDTO(Playlist playlist)
        {
            Id = playlist.Id;
            Name = playlist.Name;
            Rating = playlist.Rating;
            Songs = playlist.Songs.ToList();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Rating { get; set; }

        public virtual List<Song> Songs { get; set; }
    }
}
