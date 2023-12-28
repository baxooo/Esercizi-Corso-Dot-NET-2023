using System;
using System.Collections.Generic;

#nullable disable

namespace SpotiAPI.Models
{
    public partial class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? Rating { get; set; }
        public string Resolution { get; set; }
        public int? MoviePlaylistId { get; set; }

        public virtual MoviePlaylist MoviePlaylist { get; set; }
    }
}
