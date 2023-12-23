using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpotiAPI.Interfaces;
using SpotiAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotiAPI.Repositories
{
    internal class GenericRepository<T> : IRepository<T>
        where T : class, new()
    {
        private readonly ILogger<GenericRepository<T>> _logger;
        private readonly SpotifyContext _context;
        private UserListener _listener;
        DbSet<T> _entitySet;
        T _entity;
        public GenericRepository(ILogger<GenericRepository<T>> logger, SpotifyContext context)
        {
            _logger = logger; 
            _context = context;
            _entitySet = _context.Set<T>();
            _entity = new T();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _entitySet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"There was an error while trying to retrieve from \"{_entity.GetType().Name}\" tables");
                throw;
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                return await _entitySet.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"There was an error while trying to retrieve from \"{_entity.GetType().Name}\" tables");
                throw;
            }
        }

        public async Task<ActionResult<T>> AddNewAsync(T entity)
        {
            try
            {
                await _entitySet.AddAsync(entity);
                int changes = await _context.SaveChangesAsync();
                if (changes > 0)
                {
                    _logger.LogInformation($"Added new entity to table \"{_entity.GetType().Name}\"");
                    return entity;
                }
                else
                {
                    _logger.LogInformation($"There was a problem while trying to add a new entity to table \"{_entity.GetType().Name}\"");
                    return null;
                }
                    
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"There was an error while trying to add to \"{_entity.GetType().Name}\" tables");
                throw;
            }
        }

        public async Task<ActionResult<T>> UpdateAsync(int id, T entity)
        {
            try
            {
                var oldEntity = await _entitySet.FindAsync(id);
                if (oldEntity == null)
                {
                    _logger.LogInformation($"No entity of type \"{_entity.GetType().Name}\" with id: {id}");
                    return null;
                }
                _entitySet.Remove(oldEntity);
                await _entitySet.AddAsync(entity);
                int changes = await _context.SaveChangesAsync();
                if(changes > 0)
                {
                    _logger.LogInformation($"Updated entity successfully");
                    return entity;
                }
                else
                {
                    _logger.LogInformation($"There was a problem while trying to save the changes to db");
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,$"There was an error while trying to update an entity of type \"{_entity.GetType().Name}\"");
                throw;
            }
        }

        public async Task<ActionResult<T>> DeleteAsync(int id)
        {
            try
            {
                var entity = await _entitySet.FindAsync(id);
                _entitySet.Remove(entity); // no need for an await keyword due to it being a synchronous operation
                int changes = await _context.SaveChangesAsync();
                if (changes > 0)
                {
                    _logger.LogInformation($"Successfully deleted {id} from table \"{_entity.GetType().Name}\"");
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
                _logger.LogInformation(ex, $"There was an error while trying to delete an entity from table \"{_entity.GetType().Name}\"");
                throw;
            }
        }
    }
}
