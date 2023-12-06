using SpotiBackEnd.DbContext;
using SpotiBackEnd.Interfaces;
using SpotiBackEnd.Models.MediaModels;
using SpotiBackEnd.Models.UserModels;
using SpotiBackEnd.Repository;
using SpotiServicesLibrary.Interfaces;
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

        public MovieDTO[] GetAllUserMovies()
        {
            return _movieContext.GetAll().ToArray();
        }

        public bool UpdateMedia(MovieDTO movie)
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
