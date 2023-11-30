using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyClone.Interfaces;
using SpotifyClone.MediaModels;

namespace SpotifyClone.MediaPLayers
{
    internal interface IMediaPlayer
    {
        public void SetClasseUI(ClasseUI classe);
        public void PlayPause();
        public void Start(IRating media);
        public void Start(IPlaylist playlist);
        public void Stop();
        public void Next();
        public void Previous();
    }
}
