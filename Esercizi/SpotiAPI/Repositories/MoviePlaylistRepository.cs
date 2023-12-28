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
    public class MoviePlaylistRepository : IRepository<MoviePlaylist>
    {
        private readonly SpotifyContext _context;
        private readonly ILogger<MoviePlaylistRepository> _logger;

        public MoviePlaylistRepository(SpotifyContext context, ILogger<MoviePlaylistRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<MoviePlaylist>> GetAllAsync()
        {
            try
            {
                return await _context.MoviePlaylists.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"There was an error while trying to retrieve data from MoviePlaylists tables");
                throw;
            }
        }

        public async Task<MoviePlaylist> GetByIdAsync(int id)
        {
            try
            {
                return await _context.MoviePlaylists.FirstOrDefaultAsync(a => a.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"There was an error while trying to retrieve data from MoviePlaylist tables");
                throw;
            }
        }

        public async Task<ActionResult<MoviePlaylist>> AddNewAsync(MoviePlaylist moviePlaylist)
        {
            try
            {
                await _context.MoviePlaylists.AddAsync(moviePlaylist);
                int changes = await _context.SaveChangesAsync();
                if (changes > 0)
                {
                    _logger.LogInformation($"Added new entity to MoviePlaylist tables, id: {moviePlaylist.Id}");
                    return moviePlaylist;
                }
                else
                {
                    _logger.LogInformation($"There was an issue while trying to add a new entity to MoviePlaylist table");
                    return null;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"There was an error while trying to add MoviePlaylist {moviePlaylist.Id}");
                throw;
            }
        }

        public async Task<ActionResult<MoviePlaylist>> UpdateAsync(int id, MoviePlaylist entity)
        {
            try
            {
                var existingEntity = await _context.MoviePlaylists.FirstOrDefaultAsync(a => a.Id == id);
                if (existingEntity == null)
                {
                    _logger.LogInformation($"No MoviePlaylist with id: {id}");
                    return null;
                }
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
                int changes = await _context.SaveChangesAsync();
                if (changes > 0)
                {
                    _logger.LogInformation($"Updated MoviePlaylist entity with id: {id} successfully");
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
                _logger.LogError(ex, $"There was an error while trying to update MoviePlaylist, id: {id}");
                throw;
            }
        }

        public async Task<ActionResult<MoviePlaylist>> DeleteAsync(int id)
        {
            try
            {
                var entity = await _context.MoviePlaylists.FirstOrDefaultAsync(a => a.Id == id);
                if (entity == null)
                {
                    _logger.LogInformation($"No MoviePlaylist with id: {id}");
                    return null;
                }

                _context.MoviePlaylists.Remove(entity); // no need for an await keyword due to it being a synchronous operation
                int changes = await _context.SaveChangesAsync();
                if (changes > 0)
                {
                    _logger.LogInformation($"Successfully deleted MoviePlaylist {id} from table");
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
                _logger.LogInformation(ex, $"There was an error while trying to delete MoviePlaylist, id: {id}");
                throw;
            }
        }

    }
}
