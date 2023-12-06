using SpotiServicesLibrary.Interfaces;
using SpotiServicesLibrary.ModelsDTO;
using SpotiServicesLibrary.Services;
using System;

namespace SpotifyClone.MediaPLayers
{
    internal class MusicMediaPlayer : IMediaPlayer
    {
        protected ISongPlaylist _currentPlaylist;
        protected SongDTO _currentSong;
        private static MusicMediaPlayer _instance;
        private static UserSongServices _userServices;

        protected int _currentIndex;
        protected bool _isPlaying;
        protected bool _isPLaylist;
        protected Random _random = new Random();
        private static readonly object _lockObject = new object();

        private int _allUserSongsCount;

        public static MusicMediaPlayer Instance
        {
            get
            {
                if (_instance == null)
                    lock (_lockObject)
                        if (_instance == null)
                            _instance = new MusicMediaPlayer();
                return _instance;
            }
        }

        private MusicMediaPlayer()
        {
            _userServices = UserSongServices.Instance;
        }

        public void Start(IRating media,int userId)
        {
            SongDTO song = media as SongDTO;
            if (!_userServices.RemoveListenTimeFromUser(userId, song.Id))
            {
                StartRandom(userId);
                return;
            }

            _currentSong = song;
            song.Rating += 1;
            _isPlaying = true;
            _isPLaylist = false;
            Console.WriteLine($"\rNow Playing {song.Title}");
        }

        private void StartRandom(int userId)
        {
            SongDTO song = _userServices.GetRandomUserSong(userId);
            _currentSong = song;
            _isPlaying = true;
            _isPLaylist = false;
        }

        public void Start(IPlaylist playlist, int userId)
        {
            _currentIndex = 0;
            _currentPlaylist = (ISongPlaylist)playlist;
            _currentSong = _currentPlaylist.Songs[_currentIndex];
            _currentSong.Rating += 1;

            if (!_userServices.RemoveListenTimeFromUser(userId, _currentSong.Id))
            {
                StartRandom(userId);
                return;
            }

            _isPlaying = true;
            _isPLaylist = true;
            playlist.UpdateScore();
            Console.WriteLine($"\rNow Playing {_currentSong.Title}");
            
        }

        public void PlayPause()
        {
            if (!IsSongSelected())
            {
                Console.WriteLine("no song to play or pause, to choose a song please write the index of the song you want to play");
                return;
            }

            switch (_isPlaying)
            {
                case true:
                    Console.WriteLine($"Paused {_currentSong.Title}");
                    _isPlaying = false;
                    break;
                case false:
                    Console.WriteLine($"Playing {_currentSong.Title}");
                    _isPlaying = true;
                    break;
            }
        }

        public void Stop()
        {
            if (!IsSongSelected())
                return;
            _isPlaying = false;
            Console.WriteLine($"Stopped {_currentSong.Title}, to restart press \"p\"");
        }

        public void Next(int userId)
        {
            if (!_isPLaylist)
            {
                Console.WriteLine("Please select a playlist with \"g\"");
                return;
            }

            

            if (_currentIndex >= _currentPlaylist.Songs.Length - 1)
                _currentIndex = -1;// restarts playlist

            if (!_userServices.RemoveListenTimeFromUser(userId, _currentPlaylist.Songs[_currentIndex + 1].Id))
            {
                StartRandom(userId);
                return;
            }

            _currentSong = _currentPlaylist.Songs[_currentIndex + 1];
            _currentSong.Rating += 1;
            _currentIndex++;

            Console.WriteLine($"Now Playing {_currentSong.Title}");
            
        }

        public void Previous(int userId)
        {
            if (!_isPLaylist)
            {
                Console.WriteLine("Please select a playlist with \"g\"");
                return;
            }

            if (_currentIndex <= 0)
                _currentIndex = _currentPlaylist.Songs.Length;// goes to the end of playlist

            if (!_userServices.RemoveListenTimeFromUser(userId, _currentPlaylist.Songs[_currentIndex - 1].Id))
            {
                StartRandom(userId);
                return;
            }

            _currentSong = _currentPlaylist.Songs[_currentIndex - 1];
            _currentSong.Rating += 1;
            _currentIndex--;

            Console.WriteLine($"Now Playing {_currentSong.Title}");        }

        private bool IsSongSelected()
        {
            if (_currentSong == null)
            {
                Console.WriteLine("no song to play, pause or stop, to choose a song please write the index of the song you want to play");
                return false;
            }
            else return true;
        }
    }
}
