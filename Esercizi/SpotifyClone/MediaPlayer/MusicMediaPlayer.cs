using SpotifyClone.Interfaces;
using SpotifyClone.MediaModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.MediaPLayers
{
    internal class MusicMediaPlayer : IMediaPlayer
    {
        protected ISongPlaylist _currentPlaylist;
        protected Song _currentSong;

        protected int _currentIndex;
        protected bool _isPlaying;
        protected bool _isPLaylist;
        protected static ClasseUI _classeUI;
        protected Random _random = new Random();
        //protected static IMediaPlayer _instance;
        private static readonly object _lockObject = new object();

        public void Start(IRating media)
        {
            Song song = media as Song;
            if (_classeUI.User.RemainingTime == 0)
            {
                StartRandom();
                return;
            }

            _currentSong = song;
            song.Rating += 1;
            _isPlaying = true;
            _isPLaylist = false;
            Console.WriteLine($"\rNow Playing {song.Title}");
            int songDuration = _random.Next(90, 360);
            _classeUI.User.RemainingTime -= songDuration;
            _classeUI.User.ListenTime += songDuration;
            if (_classeUI.User.RemainingTime <= 0 && _classeUI.User.MembershipType != MembershipTypeEnum.GOLD)
            {
                _classeUI.User.RemainingTime = 0;
            }
        }

        private void StartRandom()
        {
            Song song = _classeUI.User.AllSongs[_random.Next(0, _classeUI.User.AllSongs.Length - 1)];
            _currentSong = song;
            _isPlaying = true;
            _isPLaylist = false;
            _classeUI.User.ListenTime += _random.Next(90, 360);
        }

        public void Start(IPlaylist playlist)
        {
            if (_classeUI.User.RemainingTime == 0)
            {
                StartRandom();
                return;
            }
            
            _currentIndex = 0;
            _currentPlaylist = (ISongPlaylist)playlist;
            _currentSong = _currentPlaylist.Songs[_currentIndex];
            _currentSong.Rating += 1;
            _isPlaying = true;
            _isPLaylist = true;
            playlist.UpdateScore();
            Console.WriteLine($"\rNow Playing {_currentSong.Title}");
            int songDuration = _random.Next(90, 360);
            _classeUI.User.RemainingTime -= songDuration;
            _classeUI.User.ListenTime += songDuration;
            if (_classeUI.User.RemainingTime <= 0 && _classeUI.User.MembershipType != MembershipTypeEnum.GOLD)
            {
                _classeUI.User.RemainingTime = 0;
            }
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

        public void Next()
        {
            if (!_isPLaylist)
            {
                Console.WriteLine("Please select a playlist with \"g\"");
                return;
            }

            if (_classeUI.User.RemainingTime == 0)
            {
                StartRandom();
                return;
            }

            if (_currentIndex >= _currentPlaylist.Songs.Length - 1)
                _currentIndex = -1;// restarts playlist

            _currentSong = _currentPlaylist.Songs[_currentIndex + 1];
            _currentSong.Rating += 1;
            _currentIndex++;

            Console.WriteLine($"Now Playing {_currentSong.Title}");
            int songDuration = _random.Next(90, 360);
            _classeUI.User.RemainingTime -= songDuration;
            _classeUI.User.ListenTime += songDuration;
            if (_classeUI.User.RemainingTime <= 0 && _classeUI.User.MembershipType != MembershipTypeEnum.GOLD)
            {
                _classeUI.User.RemainingTime = 0;
            }
        }

        public void Previous()
        {
            if (!_isPLaylist)
            {
                Console.WriteLine("Please select a playlist with \"g\"");
                return;
            }

            if (_classeUI.User.RemainingTime == 0)
            {
                StartRandom();
                return;
            }

            if (_currentIndex <= 0)
                _currentIndex = _currentPlaylist.Songs.Length;// goes to the end of playlist

            _currentSong = _currentPlaylist.Songs[_currentIndex - 1];
            _currentSong.Rating += 1;
            _currentIndex--;

            Console.WriteLine($"Now Playing {_currentSong.Title}");
            int songDuration = _random.Next(90, 360);
            _classeUI.User.RemainingTime -= songDuration;
            _classeUI.User.ListenTime += songDuration;
            if (_classeUI.User.RemainingTime <= 0 && _classeUI.User.MembershipType != MembershipTypeEnum.GOLD)
            {
                _classeUI.User.RemainingTime = 0;
            }
        }

        private bool IsSongSelected()
        {
            if (_currentSong == null)
            {
                Console.WriteLine("no song to play, pause or stop, to choose a song please write the index of the song you want to play");
                return false;
            }
            else return true;
        }

        public void SetClasseUI(ClasseUI classe)
        {
            _classeUI = classe;
        }
    }
}
