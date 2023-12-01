using SpotiBackEnd.Models.UserModels;

namespace SpotiBackEnd.Models.MediaModels
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Artist Artist { get; set; }
        public Album Album { get; set; }
        public string ReleaseDate {  get; set; }
        public int Duration { get; set; }
        public string Genre { get; set; }
        public int Rating { get; set; }
        public int? PlaylistId { get; set; }
    }
}