using SpotifyClone.Interfaces;
using SpotifyClone.MediaModels;
using SpotifyClone.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.MediaPLayers
{
    internal class MovieMediaPlayer : IMediaPlayer 
    {
        protected IMoviePlaylist _currentPlaylist;
        protected Movie _currentMovie;

        protected int _currentIndex;
        protected bool _isPlaying;
        protected bool _isPLaylist;
        protected static ClasseUI _classeUI;

        
        public void Next()
        {
            if (!_isPLaylist)
            {
                Console.WriteLine("Please select a playlist with \"g\"");
                return;
            }

            if (_currentIndex >= _currentPlaylist.Movies.Length - 1)
                _currentIndex = -1;// restarts playlist

            _currentMovie = _currentPlaylist.Movies[_currentIndex + 1];
            _currentMovie.Rating += 1;
            _currentIndex++;

            Console.WriteLine($"Now Playing {_currentMovie.Title}");
        }

        public void Previous()
        {
            if (!_isPLaylist)
            {
                Console.WriteLine("Please select a playlist with \"g\"");
                return;
            }

            if (_currentIndex <= 0)
                _currentIndex = _currentPlaylist.Movies.Length;// goes to the end of playlist

            _currentMovie = _currentPlaylist.Movies[_currentIndex - 1];
            _currentMovie.Rating += 1;
            _currentIndex--;

            Console.WriteLine($"Now Playing {_currentMovie.Title}");
        }

        public void PlayPause()
        {
            if (!IsMovieSelected())
            {
                Console.WriteLine("no song to play or pause, to choose a song please write the index of the song you want to play");
                return;
            }

            switch (_isPlaying)
            {
                case true:
                    Console.WriteLine($"Paused {_currentMovie.Title}");
                    _isPlaying = false;
                    break;
                case false:
                    Console.WriteLine($"Playing {_currentMovie.Title}");
                    _isPlaying = true;
                    break;
            }
        }

        public void Start(IRating media)//single movie
        {
            Movie movie = media as Movie;

            _currentMovie = movie;
            movie.Rating += 1;
            _isPlaying = true;
            _isPLaylist = false;
            Console.WriteLine($"\rNow Playing {movie.Title}");
        }

        public void Start(IPlaylist playlist)// movie playlist
        {
            _currentIndex = 0;
            _currentPlaylist = (IMoviePlaylist)playlist;
            _currentMovie = _currentPlaylist.Movies[_currentIndex];
            _currentMovie.Rating += 1;
            _isPlaying = true;
            _isPLaylist = true;
            playlist.UpdateScore();
            Console.WriteLine($"\rNow Playing {_currentMovie.Title}");
        }

        public void Stop()
        {
            if (!IsMovieSelected())
                return;
            _isPlaying = false;
            Console.WriteLine($"Stopped {_currentMovie.Title}, to restart press \"p\"");
        }

        private bool IsMovieSelected()
        {
            if (_currentMovie == null)
            {
                Console.WriteLine("no movie to play, pause or stop, " +
                    "to choose a movie please write the index of the movie you want to play");
                return false;
            }
            return true;
        }

        public void SetClasseUI(ClasseUI classe)
        {
            _classeUI = classe;
        }
    }
}
