using System;
using System.Collections.Generic;

#nullable disable

namespace SpotiAPI.Models
{
    public partial class Album
    {
        public Album()
        {
            Songs = new HashSet<Song>();
        }

        public int Id { get; set; }
        public string AlbumName { get; set; }
        public int? ArtistId { get; set; }
        public string SongsId { get; set; }
        public string ReleaseDate { get; set; }
        public string Genre { get; set; }
        public int? Rating { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
    }
}
