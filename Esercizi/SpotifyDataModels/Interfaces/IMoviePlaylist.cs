using System;
using SpotifyClone.MediaModels;

namespace SpotifyClone.Interfaces
{
    internal interface IMoviePlaylist : IPlaylist
    {
        Movie[] Movies { get; set; }
    }
}
