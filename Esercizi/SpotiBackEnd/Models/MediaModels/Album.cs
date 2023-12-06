using SpotiBackEnd.Models.UserModels;

namespace SpotiBackEnd.Models.MediaModels
{
    public class Album
    {
        public string AlbumName { get; set; }
        public Artist Artist { get; set; }
        public Song[] Songs { get; set; }
        public string ReleaseDate { get; set; }
        public string Genre { get; set; }
        public int Rating { get; set; }
    }
}