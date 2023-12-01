using SpotiServicesLibrary.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiServicesLibrary.Interfaces
{
    public interface ISongPlaylist : IPlaylist
    {
        SongDTO[] Songs { get; }
    }
}
