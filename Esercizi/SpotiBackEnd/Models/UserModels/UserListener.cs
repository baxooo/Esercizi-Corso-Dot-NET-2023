using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotiBackEnd.Models.MediaModels;
using SpotiBackEnd.Models;

namespace SpotiBackEnd.Models.UserModels
{
    public sealed class UserListener : User
    {
        public int[] PlaylistsId { get; set; }
        public int FavoritesPlaylistId { get; set; }
        public int[] RadioFavoritesId { get; set; }
        public int[] ArtistsId { get; set; }
        public int[] AlbumsId { get; set; }
        public int[] PlaylistMovieId { get; set; }
        public int[] AllUserSongsId { get; set; }
        public int[] AllMoviesId { get; set; }
        public int RemainingTime { get; set; }
        public int ListenTime { get; set; }
        public MembershipTypeEnum MembershipType { get; set; } 
        
    }
}
