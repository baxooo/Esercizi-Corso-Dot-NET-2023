using System;
using System.Collections.Generic;

#nullable disable

namespace SpotiAPI.Models
{
    public partial class MoviePlaylist
    {
        public int Id { get; set; }
        public int? Rating { get; set; }
        public string PlaylistName { get; set; }

        public virtual Movie IdNavigation { get; set; }
    }
}
