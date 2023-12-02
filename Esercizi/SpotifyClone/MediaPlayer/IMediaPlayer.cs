using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotiBackEnd.Models.UserModels;
using SpotiServicesLibrary.Interfaces;

namespace SpotifyClone.MediaPLayers
{
    internal interface IMediaPlayer
    {
        public void PlayPause();
        public void Start(IRating media, int userId);
        public void Start(IPlaylist playlist, int userId);
        public void Stop();
        public void Next(int userId);
        public void Previous(int userId);
    }
}
