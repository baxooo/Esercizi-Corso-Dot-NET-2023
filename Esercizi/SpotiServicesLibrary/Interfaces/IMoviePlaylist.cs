using SpotiServicesLibrary.ModelsDTO;
using System;

namespace SpotiServicesLibrary.Interfaces
{
    public interface IMoviePlaylist : IPlaylist
    {
        MovieDTO[] Movies { get; set; }
    }
}
