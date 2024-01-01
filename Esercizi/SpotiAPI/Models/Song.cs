using System;
using System.Collections.Generic;

namespace SpotiAPI.Models
{
    public partial class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Duration { get; set; }
        public string Genre { get; set; }
        public int Rating { get; set; }

        public int AlbumId { get; set; }
        public virtual Album Album { get; set; } = null!;

        public virtual ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();
    }
}