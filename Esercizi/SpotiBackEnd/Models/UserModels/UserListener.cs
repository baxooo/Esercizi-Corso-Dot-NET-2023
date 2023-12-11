using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotiBackEnd.Models.MediaModels;
using SpotiBackEnd.Models;

namespace SpotiBackEnd.Models.UserModels
{
    public class UserListener : User
    {
        public string PlaylistsId { get; set; }
        public string FavoritesPlaylistId { get; set; }
        public string RadioFavoritesId { get; set; }
        public string ArtistsId { get; set; }
        public string AlbumsId { get; set; }
        public string PlaylistMovieId { get; set; }
        public string AllUserSongsId { get; set; }
        public string AllMoviesId { get; set; }
        public int RemainingTime { get; set; }
        public int ListenTime { get; set; }
        public MembershipTypeEnum MembershipType { get; set; } 
        
    }
}
