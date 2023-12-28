using System;
using System.Collections.Generic;

#nullable disable

namespace SpotiAPI.Models
{
    public partial class MoviePlaylist
    {
        public MoviePlaylist()
        {
            Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }
        public int? Rating { get; set; }
        public string PlaylistName { get; set; }
        public string MoviesId { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
