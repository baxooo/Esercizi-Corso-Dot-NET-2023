using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpotiAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace SpotiAPI.Repositories
{
    public class RadioRepository
    {
        private readonly SpotifyContext _context;
        private readonly ILogger<RadioRepository> _logger;

        public RadioRepository(ILogger<RadioRepository> logger, SpotifyContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IEnumerable<Radio>> GetAllAsync()
        {
            try
            {
                return await _context.Radios.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"There was an error while trying to retrieve data from Radio tables");
                throw;
            }
        }

        public async Task<Radio> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Radios.FirstOrDefaultAsync(a => a.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"There was an error while trying to retrieve data from Radio tables");
                throw;
            }
        }

        public async Task<ActionResult<Radio>> AddNewAsync(Radio radio)
        {
            try
            {
                await _context.Radios.AddAsync(radio);
                int changes = await _context.SaveChangesAsync();
                if (changes > 0)
                {
                    _logger.LogInformation($"Added new entity to Radio tables, id: {radio.Id}");
                    return radio;
                }
                else
                {
                    _logger.LogInformation($"There was an issue while trying to add a new entity to Radio table");
                    return null;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"There was an error while trying to add Radio {radio.Id}");
                throw;
            }
        }

        public async Task<ActionResult<Radio>> UpdateAsync(int id, Radio entity)
        {
            try
            {
                var existingEntity = await _context.Radios.FirstOrDefaultAsync(a => a.Id == id);
                if (existingEntity == null)
                {
                    _logger.LogInformation($"No Radio with id: {id}");
                    return null;
                }
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
                int changes = await _context.SaveChangesAsync();
                if (changes > 0)
                {
                    _logger.LogInformation($"Updated Radio entity with id: {id} successfully");
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
                _logger.LogError(ex, $"There was an error while trying to update Radio, id: {id}");
                throw;
            }
        }

        public async Task<ActionResult<Radio>> DeleteAsync(int id)
        {
            try
            {
                var entity = await _context.Radios.FirstOrDefaultAsync(a => a.Id == id);
                if (entity == null)
                {
                    _logger.LogInformation($"No Radio with id: {id}");
                    return null;
                }

                _context.Radios.Remove(entity); // no need for an await keyword due to it being a synchronous operation
                int changes = await _context.SaveChangesAsync();
                if (changes > 0)
                {
                    _logger.LogInformation($"Successfully deleted Radio {id} from table");
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
                _logger.LogInformation(ex, $"There was an error while trying to delete Radio, id: {id}");
                throw;
            }
        }
    }
}
