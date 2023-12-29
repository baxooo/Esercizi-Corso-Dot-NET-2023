using System;
using System.Collections.Generic;

namespace SpotiAPI.Models
{

    public partial class Radio
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int OnAirPlaylistId { get; set; }
        public int Rating { get; set; }

        public virtual Playlist OnAirPlaylist { get; set; } = null!;
    }
}