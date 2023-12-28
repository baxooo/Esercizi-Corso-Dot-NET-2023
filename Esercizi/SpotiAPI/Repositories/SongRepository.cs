using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpotiAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace SpotiAPI.Repositories
{
    public class SongRepository
    {
        private readonly SpotifyContext _context;
        private readonly ILogger<SongRepository> _logger;
        public SongRepository(ILogger<SongRepository> logger, SpotifyContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IEnumerable<Song>> GetAllAsync()
        {
            try
            {
                return await _context.Songs.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"There was an error while trying to retrieve data from Songs tables");
                throw;
            }
        }

        public async Task<Song> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Songs.FirstOrDefaultAsync(a => a.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"There was an error while trying to retrieve data from Song tables");
                throw;
            }
        }

        public async Task<ActionResult<Song>> AddNewAsync(Song song)
        {
            try
            {
                await _context.Songs.AddAsync(song);
                int changes = await _context.SaveChangesAsync();
                if (changes > 0)
                {
                    _logger.LogInformation($"Added new entity to Songs tables, id: {song.Id}");
                    return song;
                }
                else
                {
                    _logger.LogInformation($"There was an issue while trying to add a new entity to Songs table");
                    return null;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"There was an error while trying to add Song {song.Id}");
                throw;
            }
        }

        public async Task<ActionResult<Song>> UpdateAsync(int id, Song entity)
        {
            try
            {
                var existingEntity = await _context.Songs.FirstOrDefaultAsync(a => a.Id == id);
                if (existingEntity == null)
                {
                    _logger.LogInformation($"No Song with id: {id}");
                    return null;
                }
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
                int changes = await _context.SaveChangesAsync();
                if (changes > 0)
                {
                    _logger.LogInformation($"Updated Song entity with id: {id} successfully");
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
                _logger.LogError(ex, $"There was an error while trying to update Song, id: {id}");
                throw;
            }
        }

        public async Task<ActionResult<Song>> DeleteAsync(int id)
        {
            try
            {
                var entity = await _context.Songs.FirstOrDefaultAsync(a => a.Id == id);
                if (entity == null)
                {
                    _logger.LogInformation($"No Song with id: {id}");
                    return null;
                }

                _context.Songs.Remove(entity); // no need for an await keyword due to it being a synchronous operation
                int changes = await _context.SaveChangesAsync();
                if (changes > 0)
                {
                    _logger.LogInformation($"Successfully deleted Song {id} from table");
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
                _logger.LogInformation(ex, $"There was an error while trying to delete Song, id: {id}");
                throw;
            }
        }

    }
}
