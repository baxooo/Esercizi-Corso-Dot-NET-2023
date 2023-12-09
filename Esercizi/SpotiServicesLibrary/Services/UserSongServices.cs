using SpotiBackEnd.DbContext;
using SpotiBackEnd.Models;
using SpotiBackEnd.Models.MediaModels;
using SpotiBackEnd.Models.UserModels;
using SpotiBackEnd.Repositories;
using SpotiServicesLibrary.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiServicesLibrary.Services
{
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

        public TimeSpan GetUserListenTime(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            if (user == null)
                throw new ArgumentException($"user does not exist");

            return TimeSpan.FromSeconds(user.RemainingTime);
        }

        public PlaylistDTO[] GetUserPlaylistsArray(int userId)
        {
            var user = _userRepository.GetUserById(userId); 
            var playlists = _playlistRepository.GetAll()
                                               .Where(p => user.PlaylistsId
                                               .Contains(p.Id));

            return playlists.ToArray();
        }
        public AlbumDTO[] GetUserAlbumsArray(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            var albums = _albumRepository.GetAll()
                                         .Where(a => user.AlbumsId
                                         .Contains(a.Id));

            return albums.ToArray() ;
        }
        public ArtistDTO[] GetUserArtistArray(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            var artists = _artistRepository.GetAll()
                                           .Where(a => user.ArtistsId
                                           .Contains(a.Id));

            return artists.ToArray();
        }
        public RadioDTO[] GetUserRadioArray(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            var radios = _radioRepository.GetAll()
                                         .Where(a => user.RadiosId
                                         .Contains(a.Id));

            return radios.ToArray() ;
        }

        public PlaylistDTO GetUserFavoritesPlaylist(int userId)
        {
            var user = _userRepository.GetUserById(userId);

            return user.Favorite;
        }
        public SongDTO[] GetAllUserSongsArray(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            var songs = _songRepository.GetAll()
                                       .Where(s => user.SongsId
                                       .Contains(s.Id));    
            return songs.ToArray();
        }

        /// <summary>
        /// removes time from user and returns a bool, true if he still has time, false if the user does not have any time left.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="songId"></param>
        /// <returns></returns>
        public bool RemoveListenTimeFromUser(int userId, int songId)
        {   // pesco utente e canzone cosi da poter rimuovere la durata della canzone dal tempo rimasto all'utente
            // per ora non ho durate sulle canzoni quindi farò in modo randomico
            var user = _userRepository.GetUserById(userId);
            var song = _songRepository.GetById(songId);

            if (user.MembershipType == MembershipTypeEnum.GOLD)
                return true;
            else if (user.RemainingTime < 0)
                return false;

            Random rnd = new Random();


            user.RemainingTime = user.RemainingTime -= rnd.Next(90, 300);
            _userRepository.UpdateUser(user);

            song.Rating++;
            _songRepository.UpdateMedia(song);

            return true;
        }

        public SongDTO GetRandomUserSong(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            var allUserSongs = GetAllUserSongsArray(userId);
            Random rnd = new Random();

            return allUserSongs[rnd.Next(0, allUserSongs.Length)];
        }
    }
}
