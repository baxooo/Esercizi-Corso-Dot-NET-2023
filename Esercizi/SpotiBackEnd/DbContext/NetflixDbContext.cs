using SpotiBackEnd.Models.MediaModels;
using SpotiBackEnd.Models.UserModels;
using SpotiLogLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiBackEnd.DbContext
{
    public class NetflixDbContext : DbContext
    {
        public List<UserListener> UserListeners { get; set; }
        public List<Movie> Movies { get; set; }
        public List<MoviePlaylist> Playlists { get; set; }

        public NetflixDbContext(string path) : base(path)
        {
            Logger logger = Logger.Instance;
            UserListeners = ReadDataFromCsv<UserListener>(path + typeof(UserListener).Name.ToString() + ".csv", logger);
            Movies = ReadDataFromCsv<Movie>(path + typeof(Movie).Name.ToString() + ".csv", logger);
            Playlists = ReadDataFromCsv<MoviePlaylist>(path + typeof(MoviePlaylist).Name.ToString() + ".csv", logger);
        }
    }

}
