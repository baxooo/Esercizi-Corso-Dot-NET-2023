using System;
using System.Collections.Generic;

namespace SpotiAPI.Models
{
    public partial class UserListener
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int RemainingTime { get; set; }
        public int ListenTime { get; set; }
        public int MembershipType { get; set; }

        public virtual ICollection<MoviePlaylist> MoviePlaylists { get; set; } = new List<MoviePlaylist>();

        public virtual ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();
    }
}
