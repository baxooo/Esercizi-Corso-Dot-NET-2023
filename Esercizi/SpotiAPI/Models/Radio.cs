using System;
using System.Collections.Generic;

#nullable disable

namespace SpotiAPI.Models
{
    public partial class Radio
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OnAirPlaylistId { get; set; }
        public int? Rating { get; set; }
    }
}
