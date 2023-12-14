using SpotiBackEnd.Interfaces;

namespace SpotiBackEnd.Models.MediaModels
{
    public class Album : Media,IRating
    {
        public string AlbumName { get; set; }
        public int ArtistId { get; set; }
        public string SongsId { get; set; }
        public string ReleaseDate { get; set; }
        public string Genre { get; set; }
        public int Rating { get; set; }
        public Album()
        {
            
        }
    }
}