using SpotiBackEnd.DbContext;
using SpotiBackEnd.Interfaces;
using SpotiBackEnd.Models.UserModels;
using SpotiBackEnd.Repository;
using SpotiServicesLibrary.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiServicesLibrary
{
    public class UserMovieServices
    {
        private static MediaRepository<UserListener,MovieDTO,dynamic> _movieContext;
        private static UserMovieServices _instance;
        private static readonly object _lockObject = new object();
        private readonly string _path = @"D:\db\";

        private UserMovieServices()
        {
            _context = new GenericDbContext(_path);
        }
        public static UserMovieServices Instance
        {
            get
            {
                if (_instance == null)
                    lock (_lockObject) 
                        if(_instance == null)
                            _instance = new UserMovieServices();

                return _instance;
            }
        }

        public MovieDTO GetMovieById(int id)
        {
            return _context.Movies.Where(m=> new MovieDTO(m)).FirstOrDefault();
        }

        public MovieDTO[] GetAllUserMovies()
        {
            return _context.Movies.Cast<MovieDTO>().ToArray();
        }

        public MoviePlaylistDTO GetPlaylistById(int id)
        {
            return _context.Playlists.Cast<MoviePlaylistDTO>().Where(m => m.PlaylistId == id).FirstOrDefault();
        }

        public MoviePlaylistDTO[] GetAllUserMoviePlaylists()
        {
            return _context.Movies.Cast<MoviePlaylistDTO>().ToArray();
        }
    }
}
