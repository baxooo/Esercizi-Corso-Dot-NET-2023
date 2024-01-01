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
    public class MoviePlaylistRepository : IPlaylistsRepository<MoviePlaylist, MoviePlaylistDTO>
    {
        private readonly SpotifyContext _context;
        private readonly ILogger<MoviePlaylistRepository> _logger;

        public MoviePlaylistRepository(SpotifyContext context, ILogger<MoviePlaylistRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<MoviePlaylistDTO>> GetAllAsync()
        {
            try
            {
                var moviePlaylists = await _context.MoviePlaylists.ToListAsync();
                var moviePlaylistDTOs = moviePlaylists.Select(m => new MoviePlaylistDTO(m));

                if(!moviePlaylistDTOs.Any())
                {
                    _logger.LogInformation("No MoviePlaylists found");
                    return null;    
                }

                return moviePlaylistDTOs;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"There was an error while trying to retrieve data from MoviePlaylists tables");
                throw;
            }
        }

        public async Task<MoviePlaylistDTO> GetByIdAsync(int id)
        {
            try
            {
                var moviePlaylist = await _context.MoviePlaylists.FirstOrDefaultAsync(a => a.Id == id);
                if (moviePlaylist == null)
                {
                    _logger.LogInformation($"No MoviePlaylist with id: {id}");
                    return null;
                }

                return new MoviePlaylistDTO(moviePlaylist);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"There was an error while trying to retrieve data from MoviePlaylist tables");
                throw;
            }
        }

        public async Task<MoviePlaylistDTO> AddNewAsync(MoviePlaylist moviePlaylist)
        {
            try
            {
                if(moviePlaylist == null)
                {
                    _logger.LogInformation($"MoviePlaylist incomplete");
                    return null;
                }
                await _context.MoviePlaylists.AddAsync(moviePlaylist);
                int changes = await _context.SaveChangesAsync();
                if (changes > 0)
                {
                    _logger.LogInformation($"Added new entity to MoviePlaylist tables, id: {moviePlaylist.Id}");
                    return new MoviePlaylistDTO(moviePlaylist);
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

        public async Task<MoviePlaylistDTO> UpdateAsync(int id, MoviePlaylist mp)
        {
            try
            {
                var existingEntity = await _context.MoviePlaylists.FirstOrDefaultAsync(a => a.Id == id);
                if (existingEntity == null)
                {
                    _logger.LogInformation($"No MoviePlaylist with id: {id}");
                    return null;
                }
                _context.Entry(existingEntity).CurrentValues.SetValues(mp);
                int changes = await _context.SaveChangesAsync();
                if (changes > 0)
                {
                    _logger.LogInformation($"Updated MoviePlaylist entity with id: {id} successfully");
                    return new MoviePlaylistDTO(mp);
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

        public async Task<MoviePlaylistDTO> DeleteAsync(int id)
        {
            try
            {
                var mp = await _context.MoviePlaylists.FirstOrDefaultAsync(a => a.Id == id);
                if (mp == null)
                {
                    _logger.LogInformation($"No MoviePlaylist with id: {id}");
                    return null;
                }

                _context.MoviePlaylists.Remove(mp); // no need for an await keyword due to it being a synchronous operation
                int changes = await _context.SaveChangesAsync();
                if (changes > 0)
                {
                    _logger.LogInformation($"Successfully deleted MoviePlaylist {id} from table");
                    return new MoviePlaylistDTO(mp);
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
