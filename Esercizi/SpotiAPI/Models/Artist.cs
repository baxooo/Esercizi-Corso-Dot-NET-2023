using System;
using System.Collections.Generic;

namespace SpotiAPI.Models
{
    public partial class Artist
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public string Genre { get; set; }
        public int Rating { get; set; }

        public virtual ICollection<Album> Albums { get; set; } = new List<Album>();
    }
}