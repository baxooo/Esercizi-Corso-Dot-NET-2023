using System;
using System.Collections.Generic;

namespace SpotiAPI.Models
{

    public partial class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public int UserListenerId { get; set; }

        public virtual ICollection<Radio> Radios { get; set; } = new List<Radio>();

        public virtual UserListener UserListener { get; set; } = null!;

        public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
    }
}