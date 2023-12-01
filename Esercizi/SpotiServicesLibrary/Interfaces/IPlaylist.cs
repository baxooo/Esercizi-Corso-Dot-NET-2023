using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiServicesLibrary.Interfaces
{
    public interface IPlaylist : IRating
    {
        public void UpdateScore();
    }
}
