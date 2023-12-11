namespace SpotiBackEnd.Models.MediaModels
{
    public class Song : Media
    {
        public string Title { get; set; }
        public string ArtistId { get; set; }
        public string AlbumId { get; set; }
        public string ReleaseDate {  get; set; }
        public int Duration { get; set; }
        public string Genre { get; set; }
        public int Rating { get; set; }
        public int PlaylistId { get; set; }
        public Song()
        {
            
        }
    }
}