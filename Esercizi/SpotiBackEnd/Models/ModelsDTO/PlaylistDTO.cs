using SpotiBackEnd.Interfaces;
using SpotiBackEnd.Models.MediaModels;
using System.Linq;

namespace SpotiBackEnd.Models.ModelsDTO
{
    internal class PlaylistDTO : IRating
    {
        public int Id { get; set; }
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
    }
}
