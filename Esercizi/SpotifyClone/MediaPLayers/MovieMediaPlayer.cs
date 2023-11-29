using SpotifyClone.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.MediaPLayers
{
    internal class MovieMediaPlayer : IMediaPlayer
    {
        public void Next()
        {
            throw new NotImplementedException();
        }

        public void PlayPause()
        {
            throw new NotImplementedException();
        }

        public void Previous()
        {
            throw new NotImplementedException();
        }

        public void SetClasseUI(ClasseUI classe)
        {
            throw new NotImplementedException();
        }

        public void Start(Movie movie)
        {
            movie.Rating += 1;
            Console.WriteLine($"\rNow Playing {movie.Title}");
        }

        public void Start(IRating media)
        {
            throw new NotImplementedException();
        }

        public void Start(IPlaylist playlist)
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
