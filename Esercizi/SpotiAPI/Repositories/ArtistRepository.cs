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
    public class ArtistRepository : IRepository<Artist>
    {
        private readonly SpotifyContext _context;
        private readonly ILogger<ArtistRepository> _logger;

        public ArtistRepository(ILogger<ArtistRepository> logger, SpotifyContext context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Artist>> GetAllAsync()
        {
            try
            {
                return await _context.Artists.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"There was an error while trying to retrieve data from Artists tables");
                throw;
            }
        }

        public async Task<Artist> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Artists.FirstOrDefaultAsync(a => a.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"There was an error while trying to retrieve data from Artists tables");
                throw;
            }
        }

        public async Task<ActionResult<Artist>> AddNewAsync(Artist artist)
        {
            try
            {
                await _context.Artists.AddAsync(artist);
                int changes = await _context.SaveChangesAsync();
                if (changes > 0)
                {
                    _logger.LogInformation($"Added new entity to Artists tables, id: {artist.Id}");
                    return artist;
                }
                else
                {
                    _logger.LogInformation($"There was an issue while trying to add a new entity to Artists table");
                    return null;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"There was an error while trying to add Artists {artist.Id}");
                throw;
            }
        }

        public async Task<ActionResult<Artist>> UpdateAsync(int id, Artist entity)
        {
            try
            {
                var existingEntity = await _context.Artists.FirstOrDefaultAsync(a => a.Id == id);
                if (existingEntity == null)
                {
                    _logger.LogInformation($"No Artist with id: {id}");
                    return null;
                }
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
                int changes = await _context.SaveChangesAsync();
                if (changes > 0)
                {
                    _logger.LogInformation($"Updated Artists entity with id: {id} successfully");
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
                _logger.LogError(ex, $"There was an error while trying to update Artist, id: {id}");
                throw;
            }
        }

        public async Task<ActionResult<Artist>> DeleteAsync(int id)
        {
            try
            {
                var entity = await _context.Artists.FirstOrDefaultAsync(a => a.Id == id);
                if (entity == null)
                {
                    _logger.LogInformation($"No Artists with id: {id}");
                    return null;
                }

                _context.Artists.Remove(entity); // no need for an await keyword due to it being a synchronous operation
                int changes = await _context.SaveChangesAsync();
                if (changes > 0)
                {
                    _logger.LogInformation($"Successfully deleted Artist {id} from table");
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
                _logger.LogInformation(ex, $"There was an error while trying to delete Artist, id: {id}");
                throw;
            }
        }

    }
}
