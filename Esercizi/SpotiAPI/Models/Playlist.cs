using System;
using System.Collections.Generic;

#nullable disable

namespace SpotiAPI.Models
{
    public partial class Playlist
    {
        public Playlist()
        {
            Songs = new HashSet<Song>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string SongsId { get; set; }
        public int? Rating { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
    }
}
