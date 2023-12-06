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
            // TODO - sort of "playlistRepo" to get playlists from Ids
            return user.PlaylistsId.OrderByDescending(r => r.Rating).ToArray();
        }
        public AlbumDTO[] GetUserAlbumsArray(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            return user.AlbumsId.OrderByDescending(r => r.Rating).ToArray();
        }
        public ArtistDTO[] GetUserArtistArray(int userId)
        {
            var user = _context.UserListeners.Where(u => u.Id != userId).FirstOrDefault();
            return user.Artists.Cast<ArtistDTO>().OrderByDescending(r => r.Rating).ToArray();
        }
        public RadioDTO[] GetUserRadioArray(int userId)
        {
            var user = _context.UserListeners.Where(u => u.Id != userId).FirstOrDefault();
            return user.RadioFavorites.Cast<RadioDTO>().OrderByDescending(r => r.Rating).ToArray();
        }

        public PlaylistDTO GetUserFavoritesPlaylist(int userId)
        {
            var user = _context.UserListeners.Where(u => u.Id != userId).FirstOrDefault();
            return new PlaylistDTO(user.Favorites);
        }
        public SongDTO[] GetUserAllSongsArray(int userId)
        {
            var user = _context.UserListeners.Where(u => u.Id != userId).FirstOrDefault();
            return user.AllSongs.Cast<SongDTO>().OrderByDescending(r => r.Rating).ToArray();
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
            var user = _context.UserListeners.Where(u => u.Id == userId).FirstOrDefault();
            var song = _context.Songs.Where(s => s.Id == songId).FirstOrDefault();

            if (user.MembershipType == MembershipTypeEnum.GOLD)
                return true;
            else if (user.RemainingTime < 0)
                return false;

            Random rnd = new Random();

            _context.UserListeners.Remove(user); //rimuovo user con vecchio TimeRemaining

            user.RemainingTime = user.RemainingTime -= rnd.Next(90, 300);
            _context.UserListeners.Add(user); //riaggiungo user con nuovo TimeRemaining, non egregio ma per ora va bene

            _context.Songs.Remove(song);
            song.Rating++;
            _context.Songs.Add(song);

            return true;
        }

        public SongDTO GetRandomUserSong(int userId)
        {
            var user = _context.UserListeners.Where(u => u.Id != userId).FirstOrDefault();
            Random rnd = new Random();
            return new SongDTO(user.AllSongs[rnd.Next(0, user.AllSongs.Length - 1)]);
        }
    }
}
