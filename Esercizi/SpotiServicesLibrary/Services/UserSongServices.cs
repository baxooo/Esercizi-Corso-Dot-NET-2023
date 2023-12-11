using SpotiBackEnd.DbContext;
using SpotiBackEnd.Models;
using SpotiBackEnd.Models.MediaModels;
using SpotiBackEnd.Models.UserModels;
using SpotiBackEnd.Models.UserModelsResponse;
using SpotiBackEnd.Repositories;
using SpotiServicesLibrary.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiServicesLibrary.Services
{
    /// <summary>
    /// Service class responsible for managing user-specific song-related operations.
    /// </summary>
    public class UserSongServices
    {
        private readonly MediaRepository<Song, SongDTO, SongDTO> _songRepository;
        private readonly MediaRepository<Album, AlbumDTO, AlbumDTO> _albumRepository;
        private readonly MediaRepository<Artist, ArtistDTO, ArtistDTO> _artistRepository;
        private readonly MediaRepository<Playlist, PlaylistDTO, PlaylistDTO> _playlistRepository;
        private readonly MediaRepository<Radio, RadioDTO, RadioDTO> _radioRepository;
        private readonly UserRepository<UserListener, UserResponseDTO, UserDTO> _userRepository;
        private static UserSongServices _instance;
        private static readonly object _lockObject = new object();
        private readonly string _path = @"D:\db\";

        public static UserSongServices Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lockObject)
                    {
                        if (_instance == null)
                            _instance = new UserSongServices();
                    }
                }
                return _instance;
            }
        }

        private UserSongServices()
        {
            _songRepository = new MediaRepository<Song, SongDTO, SongDTO>(_path);
            _userRepository = new UserRepository<UserListener, UserResponseDTO, UserDTO>(_path);
            _albumRepository = new MediaRepository<Album, AlbumDTO, AlbumDTO>(_path);
            _artistRepository = new MediaRepository<Artist, ArtistDTO, ArtistDTO>(_path);
            _playlistRepository = new MediaRepository<Playlist, PlaylistDTO, PlaylistDTO>(_path);
            _radioRepository = new MediaRepository<Radio,RadioDTO, RadioDTO>(_path);    
        }

        public UserDTO Login(string username, string password)
        {
            return _userRepository.GetUser(username, password);
        }

        /// <summary>
        /// Retrieves the remaining listen time for a specific user.
        /// </summary>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <returns>The remaining listen time for the user as a TimeSpan.</returns>
        /// <exception cref="ArgumentException">Thrown if the user does not exist.</exception>
        public TimeSpan GetUserListenTime(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            if (user == null)
                throw new ArgumentException($"user does not exist");

            return TimeSpan.FromSeconds(user.RemainingTime);
        }

        /// <summary>
        /// Retrieves an array of <typeparamref name="PlaylistDTO"/> objects associated with a specific user.
        /// </summary>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <typeparam name="PlaylistDTO"></typeparam>
        public PlaylistDTO[] GetUserPlaylistsArray(int userId)
        {
            var user = _userRepository.GetUserById(userId); 
            var playlists = _playlistRepository.GetAll()
                                               .Where(p => user.PlaylistsId
                                               .Contains(p.Id));

            return playlists.ToArray();
        }

        /// <summary>
        /// Retrieves an array of AlbumDTO objects associated with a specific user.
        /// </summary>
        /// <param name="userId">The unique identifier of the user.</param>
        public AlbumDTO[] GetUserAlbumsArray(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            var albums = _albumRepository.GetAll()
                                         .Where(a => user.AlbumsId
                                         .Contains(a.Id));

            return albums.ToArray() ;
        }

        /// <summary>
        /// Retrieves an array of ArtistDTO objects associated with a specific user.
        /// </summary>
        /// <param name="userId">The unique identifier of the user.</param>
        public ArtistDTO[] GetUserArtistArray(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            var artists = _artistRepository.GetAll()
                                           .Where(a => user.ArtistsId
                                           .Contains(a.Id));

            return artists.ToArray();
        }

        /// <summary>
        /// Retrieves an array of RadioDTO objects associated with a specific user.
        /// </summary>
        /// <param name="userId">The unique identifier of the user.</param>
        public RadioDTO[] GetUserRadioArray(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            var radios = _radioRepository.GetAll()
                                         .Where(a => user.RadiosId
                                         .Contains(a.Id));

            return radios.ToArray() ;
        }

        /// <summary>
        /// Retrieves a PlaylistDTO associated with a specific user.
        /// </summary>
        /// <param name="userId">The unique identifier of the user.</param>
        //public PlaylistDTO GetUserFavoritesPlaylist(int userId)
        //{
        //    var user = _userRepository.GetUserById(userId);

        //    return user.Favorite;
        //}

        /// <summary>
        /// Retrieves an array of SongDTO objects associated with a specific user.
        /// </summary>
        /// <param name="userId">The unique identifier of the user.</param>
        public SongDTO[] GetAllUserSongsArray(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            var songs = _songRepository.GetAll()
                                       .Where(s => user.SongsId
                                       .Contains(s.Id));    
            return songs.ToArray();
        }

        /// <summary>
        /// Removes time from user and returns a bool.
        /// </summary>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <param name="songId">The unique identifier of the song.</param>
        /// <returns>
        ///   <c>true</c> if the listen time is successfully removed; 
        ///   <c>false</c> if the user has insufficient remaining time.
        /// </returns>
        public bool RemoveListenTimeFromUser(int userId, int songId)
        {
            var user = _userRepository.GetUserById(userId);
            var song = _songRepository.GetById(songId);

            // Check if the user has a GOLD membership, in which case, listen time is not deducted
            if (user.MembershipType == MembershipTypeEnum.GOLD)
                return true;

            // Check if the user has sufficient remaining time to listen to the song
            else if (user.RemainingTime < 0)
                return false;

            // Deduct a random duration between 90 and 300 seconds from the user's remaining time
            Random rnd = new Random();
            user.RemainingTime -= rnd.Next(90, 300);

            _userRepository.UpdateUser(user);

            song.Rating++;
            _songRepository.Update(song);

            // Return true to indicate successful listen time removal
            return true;
        }

        /// <summary>
        /// Retrieves a random SongDTO object associated with a specific user.
        /// </summary>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <returns>A random SongDTO object associated with the user, or null if the user has no songs.</returns>
        public SongDTO GetRandomUserSong(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            var allUserSongs = GetAllUserSongsArray(userId);
            Random rnd = new Random();

            return allUserSongs[rnd.Next(0, allUserSongs.Length)];
        }
    }
}
