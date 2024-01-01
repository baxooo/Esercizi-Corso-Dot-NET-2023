using System;
using System.Collections.Generic;

namespace SpotiAPI.Models
{

    public partial class MoviePlaylist
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Name { get; set; }

        public int UserListenerId { get; set; }
        public virtual UserListener UserListener { get; set; } = null!;

        public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}