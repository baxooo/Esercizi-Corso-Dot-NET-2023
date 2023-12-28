using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpotiAPI.Interfaces;
using SpotiAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpotiAPI.Repositories
{
    public class AlbumRepository : IRepository<Album>
    {
        private readonly ILogger<AlbumRepository> _logger;
        private readonly SpotifyContext _context;
        public AlbumRepository(SpotifyContext context, ILogger<AlbumRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Album>> GetAllAsync()
        {
            try
            {
                return await _context.Albums.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"There was an error while trying to retrieve data from Album tables");
                throw;
            }
        }

        public async Task<Album> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Albums.FirstOrDefaultAsync(a => a.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"There was an error while trying to retrieve data from Album tables");
                throw;
            }
        }

        public async Task<ActionResult<Album>> AddNewAsync(Album album)
        {
            try
            {
                await _context.Albums.AddAsync(album);
                int changes = await _context.SaveChangesAsync();
                if (changes > 0)
                {
                    _logger.LogInformation($"Added new entity to Album tables, id: {album.Id}");
                    return album;
                }
                else
                {
                    _logger.LogInformation($"There was an issue while trying to add a new entity to Album table ");
                    return null;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"There was an error while trying to add Album {album.Id}");
                throw;
            }
        }

        public async Task<ActionResult<Album>> UpdateAsync(int id, Album entity)
        {
            try
            {
                var existingEntity = await _context.Albums.FirstOrDefaultAsync(a => a.Id == id);
                if (existingEntity == null)
                {
                    _logger.LogInformation($"No Album with id: {id}");
                    return null;
                }
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
                int changes = await _context.SaveChangesAsync();
                if (changes > 0)
                {
                    _logger.LogInformation($"Updated entity successfully");
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
                _logger.LogError(ex, $"There was an error while trying to update Album, id: {id}");
                throw;
            }
        }

        public async Task<ActionResult<Album>> DeleteAsync(int id)
        {
            try
            {
                var entity = await _context.Albums.FirstOrDefaultAsync(a => a.Id == id);
                if (entity == null)
                {
                    _logger.LogInformation($"No Album with id: {id}");
                    return null;
                }

                _context.Albums.Remove(entity); // no need for an await keyword due to it being a synchronous operation
                int changes = await _context.SaveChangesAsync();
                if (changes > 0)
                {
                    _logger.LogInformation($"Successfully deleted Album {id} from table");
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
                _logger.LogInformation(ex, $"There was an error while trying to delete Album, id: {id}");
                throw;
            }
        }
    }
}
