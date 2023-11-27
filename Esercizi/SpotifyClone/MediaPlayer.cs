using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyClone.Interfaces;
using SpotifyClone.Models;

namespace SpotifyClone
{
    internal class MediaPlayer
    {
        private int _currentIndex;
        private IPlaylist _currentPlaylist;
        private Song _currentSong;
        private bool _isPlaying;
        private bool _isPLaylist;
        private ClasseUI _classeUI;

        public MediaPlayer(ClasseUI classe)
        {
            _classeUI = classe;
        }

        public void Start(Song song)
        {
            if(_isPlaying) 
                return; 
            _currentSong = song;
            _isPlaying = true;
            _isPLaylist = false;
            song.Rating += 1;
            Console.WriteLine($"\rNow Playing {_currentSong.Title}");
        }
        public void Start(IPlaylist playlist) 
        {
            
            _currentIndex = 0;
            _currentPlaylist = playlist;
            _currentSong = _currentPlaylist.Songs[_currentIndex];
            _currentSong.Rating += 1;
            _isPlaying = true;
            _isPLaylist = true;
            playlist.UpdateScore();
            Console.WriteLine($"\rNow Playing {_currentSong.Title}");
        }

        public void PlayPause()
        {
            if(!IsSongSelected())
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
            if (_currentIndex >= _currentPlaylist.Songs.Length - 1)
                _currentIndex = -1;// restarts playlist
            
            _currentSong = _currentPlaylist.Songs[_currentIndex + 1];
            _currentSong.Rating += 1;
            _currentIndex++;

            Console.WriteLine($"Now Playing {_currentSong.Title}");
        }

        public void Previous() 
        {
            if (!_isPlaying && !_isPLaylist) 
                return;

            if (_currentIndex <= 0)
                _currentIndex = _currentPlaylist.Songs.Length;// goes to the end of playlist
            
            _currentSong = _currentPlaylist.Songs[_currentIndex - 1];
            _currentSong.Rating += 1;
            _currentIndex--;

            Console.WriteLine($"Now Playing {_currentSong.Title}");
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
    }
}
