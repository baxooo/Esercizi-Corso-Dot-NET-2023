using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpotiAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace SpotiAPI.Repositories
{
    public class PlaylistRepository
    {
        private readonly SpotifyContext _context;
        private readonly ILogger<PlaylistRepository> _logger;

        public PlaylistRepository(SpotifyContext context, ILogger<PlaylistRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Playlist>> GetAllAsync()
        {
            try
            {
                return await _context.Playlists.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"There was an error while trying to retrieve data from Playlists tables");
                throw;
            }
        }

        public async Task<Playlist> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Playlists.FirstOrDefaultAsync(a => a.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"There was an error while trying to retrieve data from Playlist tables");
                throw;
            }
        }

        public async Task<ActionResult<Playlist>> AddNewAsync(Playlist playlist)
        {
            try
            {
                await _context.Playlists.AddAsync(playlist);
                int changes = await _context.SaveChangesAsync();
                if (changes > 0)
                {
                    _logger.LogInformation($"Added new entity to Playlist tables, id: {playlist.Id}");
                    return playlist;
                }
                else
                {
                    _logger.LogInformation($"There was an issue while trying to add a new entity to Playlist table");
                    return null;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"There was an error while trying to add Playlist {playlist.Id}");
                throw;
            }
        }

        public async Task<ActionResult<Playlist>> UpdateAsync(int id, Playlist entity)
        {
            try
            {
                var existingEntity = await _context.Playlists.FirstOrDefaultAsync(a => a.Id == id);
                if (existingEntity == null)
                {
                    _logger.LogInformation($"No Playlist with id: {id}");
                    return null;
                }
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
                int changes = await _context.SaveChangesAsync();
                if (changes > 0)
                {
                    _logger.LogInformation($"Updated Playlist entity with id: {id} successfully");
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
                _logger.LogError(ex, $"There was an error while trying to update Playlist, id: {id}");
                throw;
            }
        }

        public async Task<ActionResult<Playlist>> DeleteAsync(int id)
        {
            try
            {
                var entity = await _context.Playlists.FirstOrDefaultAsync(a => a.Id == id);
                if (entity == null)
                {
                    _logger.LogInformation($"No Playlist with id: {id}");
                    return null;
                }

                _context.Playlists.Remove(entity); // no need for an await keyword due to it being a synchronous operation
                int changes = await _context.SaveChangesAsync();
                if (changes > 0)
                {
                    _logger.LogInformation($"Successfully deleted Playlist {id} from table");
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
                _logger.LogInformation(ex, $"There was an error while trying to delete Playlist, id: {id}");
                throw;
            }
        }
    }
}
