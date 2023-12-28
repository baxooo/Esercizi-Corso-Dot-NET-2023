using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpotiAPI.Interfaces;
using SpotiAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace SpotiAPI.Repositories
{
    public class MovieRepository : IRepository<Movie>
    {
        private readonly SpotifyContext _context;
        private readonly ILogger<MovieRepository> _logger;

        public MovieRepository(SpotifyContext context, ILogger<MovieRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            try
            {
                return await _context.Movies.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"There was an error while trying to retrieve data from Movies tables");
                throw;
            }
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Movies.FirstOrDefaultAsync(a => a.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"There was an error while trying to retrieve data from Movies tables");
                throw;
            }
        }

        public async Task<ActionResult<Movie>> AddNewAsync(Movie movie)
        {
            try
            {
                await _context.Movies.AddAsync(movie);
                int changes = await _context.SaveChangesAsync();
                if (changes > 0)
                {
                    _logger.LogInformation($"Added new entity to Movie tables, id: {movie.Id}");
                    return movie;
                }
                else
                {
                    _logger.LogInformation($"There was an issue while trying to add a new entity to Movie table");
                    return null;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"There was an error while trying to add Movie {movie.Id}");
                throw;
            }
        }

        public async Task<ActionResult<Movie>> UpdateAsync(int id, Movie entity)
        {
            try
            {
                var existingEntity = await _context.Movies.FirstOrDefaultAsync(a => a.Id == id);
                if (existingEntity == null)
                {
                    _logger.LogInformation($"No Movie with id: {id}");
                    return null;
                }
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
                int changes = await _context.SaveChangesAsync();
                if (changes > 0)
                {
                    _logger.LogInformation($"Updated Movies entity with id: {id} successfully");
                    return entity;
                }
                else
                {
                    _logger.LogInformation($"There was a problem while trying to save changes to db");
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"There was an error while trying to update Movie, id: {id}");
                throw;
            }
        }

        public async Task<ActionResult<Movie>> DeleteAsync(int id)
        {
            try
            {
                var entity = await _context.Movies.FirstOrDefaultAsync(a => a.Id == id);
                if (entity == null)
                {
                    _logger.LogInformation($"No Movie with id: {id}");
                    return null;
                }

                _context.Movies.Remove(entity); // no need for an await keyword due to it being a synchronous operation
                int changes = await _context.SaveChangesAsync();
                if (changes > 0)
                {
                    _logger.LogInformation($"Successfully deleted Movie {id} from table");
                    return entity;
                }
                else
                {
                    _logger.LogInformation($"There is an issue while trying to save changes to db");
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, $"There was an error while trying to delete Movie, id: {id}");
                throw;
            }
        }
    }
}
