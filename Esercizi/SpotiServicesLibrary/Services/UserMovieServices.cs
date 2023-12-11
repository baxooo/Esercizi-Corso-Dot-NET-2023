using SpotiBackEnd.Models.MediaModels;
using SpotiBackEnd.Repositories;
using SpotiServicesLibrary.ModelsDTO;
using System;
using System.Linq;

namespace SpotiServicesLibrary.Services
{
    public class UserMovieServices
    {
        private readonly MediaRepository<Movie, MovieDTO, MovieDTO> _movieContext;// TODO movieRequestDto && movieResponseDTO
        private static UserMovieServices _instance;
        private static readonly object _lockObject = new object();
        private readonly string _path = @"D:\db\";

        private UserMovieServices()
        {
            _movieContext = new MediaRepository<Movie, MovieDTO, MovieDTO>(_path);
        }
        public static UserMovieServices Instance
        {
            get
            {
                if (_instance == null)
                    lock (_lockObject)
                        if (_instance == null)
                            _instance = new UserMovieServices();

                return _instance;
            }
        }

        public MovieDTO GetMovieById(int id)
        {
            return _movieContext.GetById(id);
        }

        public MovieDTO[] GetAllUserMovies(int userId)
        {
            return _movieContext.GetAll().Where(m => m.Id == userId).ToArray();
        }

        public MoviePlaylistDTO[] GetAllUserMoviePlaylists(int userId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateMovie(MovieDTO movie)
        {
            return _movieContext.Update(movie);
        }

        public MovieDTO[] GetAllMedia()
        {
            return _movieContext.GetAll().ToArray();
        }

        public MovieDTO GetMediaById(int id)
        {
            return _movieContext.GetById(id);
        }

        public bool DeleteMedia(int id)
        {
            return _movieContext.DeleteById(id);
        }
    }
}
