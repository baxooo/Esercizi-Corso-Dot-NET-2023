using System;
using System.Collections.Generic;

#nullable disable

namespace SpotiAPI.Models
{
    public partial class UserListener
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? PlaylistsId { get; set; }
        public int? FavoritesPlaylistId { get; set; }
        public int? RadioFavoritesId { get; set; }
        public int? ArtistsId { get; set; }
        public int? AlbumsId { get; set; }
        public int? PlaylistMovieId { get; set; }
        public int? AllUserSongsId { get; set; }
        public int? AllMoviesId { get; set; }
        public int? RemainingTime { get; set; }
        public int? ListenTime { get; set; }
        public int? MembershipType { get; set; }
    }
}
