using System;
using System.Collections.Generic;

namespace SpotiAPI.Models
{
    public partial class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int Rating { get; set; }
        public string? Resolution { get; set; }

        public virtual ICollection<MoviePlaylist> MoviePlaylists { get; set; } = new List<MoviePlaylist>();
    }
}