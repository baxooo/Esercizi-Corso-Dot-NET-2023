using System;
using System.Collections.Generic;

namespace SpotiAPI.Models
{

    public partial class Album
    {
        public int Id { get; set; }
        public string AlbumName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public int Rating { get; set; }

        public int ArtistId { get; set; }
        public virtual Artist? Artist { get; set; }

        public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
    }
}