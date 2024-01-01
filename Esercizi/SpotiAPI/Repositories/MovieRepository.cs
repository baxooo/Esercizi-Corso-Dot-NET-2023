using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpotiAPI.Interfaces;
using SpotiAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using SpotiAPI.Models.ModelsDTO;

namespace SpotiAPI.Repositories
{
    public class MovieRepository : IBasicRepository<MovieDTO>
    {
        private readonly SpotifyContext _context;
        private readonly ILogger<MovieRepository> _logger;

        public MovieRepository(SpotifyContext context, ILogger<MovieRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IEnumerable<MovieDTO>> GetAllAsync()
        {
            try
            {
                var movies = await _context.Movies.ToListAsync();

                if (!movies.Any())
                {
                    _logger.LogInformation("No movies found");
                    return null;
                }

                return movies.Select(m => new MovieDTO(m)); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"There was an error while trying to retrieve data from Movies tables");
                throw;
            }
        }

        public async Task<MovieDTO> GetByIdAsync(int id)
        {
            try
            {
                var movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);

                if (movie == null)
                {
                    _logger.LogInformation($"No movie with id: {id}");
                    return null;
                }

                return new MovieDTO(movie);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"There was an error while trying to retrieve data from Movies tables");
                throw;
            }
        }
    }
}
