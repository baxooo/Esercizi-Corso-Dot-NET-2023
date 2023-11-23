using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone
{
    internal class MediaPlayer
    {
        private int _currentIndex;
        private IPlaylist _currentPlaylist;
        private Song _currentSong;
        private bool _isPlaying;
        private bool _isPLaylist;


        public void Start(Song song)
        {
            _currentSong = song;
            _isPlaying = true;
            _isPLaylist = false;
            Console.WriteLine($"Now Playing {_currentSong.Title}");
        }
        public void Start(IPlaylist playlist) 
        {
            _currentIndex = 0;
            _currentPlaylist = playlist;
            _isPlaying = true;
            _isPLaylist = true;
        }

        public void PlayPause()
        {
            if(!IsSongSelected())
            {
                Console.WriteLine("no song to play or pause, to choose a song please write \"p\" followed by the index of the song you want to play");
                return;
            }

            switch (_isPlaying)
            {
                case true:
                    Console.WriteLine($"Paused {_currentSong.Title}");
                    break;
                case false:
                    Console.WriteLine($"Resumed {_currentSong.Title}");
                    break;
            }

        }

        public void Stop()
        {
            if (!IsSongSelected())
                return;
            Console.WriteLine($"Stopped {_currentSong.Title}, to restart press \"p\"");
        }

        public void Next()
        {
            if (!_isPlaying && !_isPLaylist)
                return;
            _currentSong = _currentPlaylist.Songs[_currentIndex + 1];
            _currentIndex++;
            Console.WriteLine($"Now Playing {_currentSong.Title}");
        }

        public void Previous() 
        {
            if (!_isPlaying && !_isPLaylist) 
                return;
            _currentSong = _currentPlaylist.Songs[_currentIndex + 1];
            _currentIndex++;
            Console.WriteLine($"Now Playing {_currentSong.Title}");
        }

        private bool IsSongSelected()
        {
            if (_currentSong == null)
            {
                Console.WriteLine("no song to play, pause or stop, to choose a song please write \"p\" followed by the index of the song you want to play ex.\"p1\"");
                return false;
            }
            else return true;
        }
    }
}
