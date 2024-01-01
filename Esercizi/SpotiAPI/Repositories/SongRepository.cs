using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpotiAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using SpotiAPI.Interfaces;
using SpotiAPI.Models.ModelsDTO;

namespace SpotiAPI.Repositories
{
    public class SongRepository : IBasicRepository<SongDTO>
    {
        private readonly SpotifyContext _context;
        private readonly ILogger<SongRepository> _logger;
        public SongRepository(ILogger<SongRepository> logger, SpotifyContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IEnumerable<SongDTO>> GetAllAsync()
        {
            try
            {
                var songs = await _context.Songs.ToListAsync();
                if (!songs.Any())
                {
                    _logger.LogInformation("No songs found");
                    return null;
                }

                return songs.Select(s => new SongDTO(s));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"There was an error while trying to retrieve data from Songs tables");
                throw;
            }
        }

        public async Task<SongDTO> GetByIdAsync(int id)
        {
            try
            {
                var song = await _context.Songs.FirstOrDefaultAsync(a => a.Id == id);
                if (song == null)
                {
                    _logger.LogInformation($"No song with id: {id}");
                    return null;
                }

                return new SongDTO(song);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"There was an error while trying to retrieve data from Song tables");
                throw;
            }
        }
    }
}
