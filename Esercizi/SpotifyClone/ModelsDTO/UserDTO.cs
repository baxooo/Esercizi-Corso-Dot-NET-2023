using SpotifyClone.MediaModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.ModelsDTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        // TODO - rimuovere queste properties 
        public PlaylistDTO Favorites { get; set; }
        public PlaylistDTO[] Playlists { get; set; }
        public RadioDTO[] RadioFavorites { get; set; }
        public ArtistDTO[] Artists { get; set; }
        public AlbumDTO[] Albums { get; set; }
        public MoviePlaylistDTO[] PlaylistMovie { get; set; }
        public SongDTO[] AllSongs { get; set; }
        public MovieDTO[] AllMovies { get; set; }
    }
}
