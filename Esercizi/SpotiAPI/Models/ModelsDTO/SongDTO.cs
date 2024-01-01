using System;

namespace SpotiAPI.Models.ModelsDTO
{
    public class SongDTO
    {
        public SongDTO()
        {
            
        }

        public SongDTO(Song song)
        {
            Id = song.Id;
            Title = song.Title;
            ReleaseDate = song.ReleaseDate;
            Duration = song.Duration;
            Genre = song.Genre;
            Rating = song.Rating;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Duration { get; set; }
        public string Genre { get; set; }
        public int Rating { get; set; }
    }
}
