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
        private Playlist _currentPlaylist;


        public void Start(Song song)
        {

        }
        public void Start(Playlist playlist) 
        {
            _currentIndex = 0;
            _currentPlaylist = playlist;
        }
        public void Play(Album album)
        {

        }



        public void PlayPause()
        {

        }

        public void Stop()
        { 
        
        }

        public void Next()
        {

        }

        public void Previous() 
        { 
            
        }
    }
}
