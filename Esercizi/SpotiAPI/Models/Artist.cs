using System;
using System.Collections.Generic;

#nullable disable

namespace SpotiAPI.Models
{
    public partial class Artist
    {
        public Artist()
        {
            Albums = new HashSet<Album>();
            Songs = new HashSet<Song>();
        }

        public int Id { get; set; }
        public string Alias { get; set; }
        public string Genre { get; set; }
        public int? Rating { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
    }
}
