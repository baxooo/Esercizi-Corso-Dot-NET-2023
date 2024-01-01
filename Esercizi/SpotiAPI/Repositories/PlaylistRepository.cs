using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpotiAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using SpotiAPI.Models.ModelsDTO;
using SpotiAPI.Interfaces;
using System.Linq;

namespace SpotiAPI.Repositories
{
    public class PlaylistRepository : IPlaylistsRepository<Playlist,PlaylistDTO>
    {
        private readonly SpotifyContext _context;
        private readonly ILogger<PlaylistRepository> _logger;

        public PlaylistRepository(SpotifyContext context, ILogger<PlaylistRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<PlaylistDTO>> GetAllAsync()
        {
            try
            {
                var playlists = await _context.Playlists.ToListAsync();
                if (!playlists.Any())
                {
                    _logger.LogInformation("No playlists found");
                    return null;
                }

                return playlists.Select(p => new PlaylistDTO(p));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"There was an error while trying to retrieve data from Playlists tables");
                throw;
            }
        }

        public async Task<PlaylistDTO> GetByIdAsync(int id)
        {
            try
            {
                var playlist = await _context.Playlists.FirstOrDefaultAsync(a => a.Id == id);
                if (playlist == null)
                {
                    _logger.LogInformation($"No Playlist with id: {id}");
                    return null;
                }

                return new PlaylistDTO(playlist);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"There was an error while trying to retrieve data from Playlist tables");
                throw;
            }
        }

        public async Task<PlaylistDTO> AddNewAsync(Playlist playlist)
        {
            try
            {
                await _context.Playlists.AddAsync(playlist);
                int changes = await _context.SaveChangesAsync();
                if (changes > 0)
                {
                    _logger.LogInformation($"Added new entity to Playlist tables, id: {playlist.Id}");
                    return new PlaylistDTO(playlist);
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

        public async Task<PlaylistDTO> UpdateAsync(int id, Playlist entity)
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
                    return new PlaylistDTO(entity);
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

        public async Task<PlaylistDTO> DeleteAsync(int id)
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
                    return new PlaylistDTO(entity);
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
