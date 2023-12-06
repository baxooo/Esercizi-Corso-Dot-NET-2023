using SpotiServicesLibrary;
using SpotiServicesLibrary.Interfaces;
using SpotiServicesLibrary.ModelsDTO;
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
        protected MovieDTO _currentMovie;

        protected int _currentIndex;
        protected bool _isPlaying;
        protected bool _isPLaylist;
        private UserMovieServices _userServices;
        private static readonly object _lockObject = new object();

        private static MovieMediaPlayer _instance;
        public static MovieMediaPlayer Instance
        {
            get
            {
                if (_instance == null)
                    lock (_lockObject) 
                        if (_instance == null)
                            _instance = new MovieMediaPlayer();
                return _instance;
            }
        }

        private MovieMediaPlayer()
        {
            _userServices = UserMovieServices.Instance;
        }

        public void Next(int userId)
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

        public void Previous(int userId)
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

        public void Start(IRating media, int userId)//single movie
        {
            MovieDTO movie = media as MovieDTO;

            _currentMovie = movie;
            movie.Rating += 1;
            _isPlaying = true;
            _isPLaylist = false;
            Console.WriteLine($"\rNow Playing {movie.Title}");
        }

        public void Start(IPlaylist playlist, int userId)// movie playlist
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
    }
}
