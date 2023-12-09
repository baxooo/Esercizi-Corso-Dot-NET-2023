using SpotiBackEnd.Models;
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
        public PlaylistDTO Favorite { get; set; }
        public MembershipTypeEnum MembershipType { get; set; }
    }
}
