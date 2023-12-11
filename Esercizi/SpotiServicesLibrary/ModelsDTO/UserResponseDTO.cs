using SpotiBackEnd.Models;
using SpotiBackEnd.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiServicesLibrary.ModelsDTO
{
    internal class UserResponseDTO : UserDTO
    {
        public int RemainingTime { get; set; }
        public int[] PlaylistsId { get; set; }
        public int[] AlbumsId { get; set; }
        public int[] ArtistsId { get; set; }
        public int[] RadiosId { get; set; }
        public int[] SongsId { get; set; }
        public MembershipTypeEnum MembershipType { get; set; }

        public UserResponseDTO(UserListener user)
        {
            Id = user.Id;
            Name = user.Name;
            RemainingTime = user.RemainingTime;
            PlaylistsId = user.PlaylistsId.Split('|').Select(p => int.Parse(p)).ToArray();
            AlbumsId = user.AlbumsId.Split('|').Select(a => int.Parse(a)).ToArray();
            ArtistsId = user.ArtistsId.Split('|').Select(a => int.Parse(a)).ToArray();
            RadiosId = user.RadioFavoritesId.Split('|').Select(a => int.Parse(a)).ToArray();
            SongsId = user.AllUserSongsId.Split('|').Select(a => int.Parse(a)).ToArray();
            MembershipType = user.MembershipType;
        }
        public UserResponseDTO() 
        {
            
        }
    }
}
