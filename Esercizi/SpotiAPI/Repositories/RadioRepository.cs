using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpotiAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using SpotiAPI.Models.ModelsDTO;
using System.Linq;
using SpotiAPI.Interfaces;

namespace SpotiAPI.Repositories
{
    public class RadioRepository : IBasicRepository<RadioDTO>
    {
        private readonly SpotifyContext _context;
        private readonly ILogger<RadioRepository> _logger;

        public RadioRepository(ILogger<RadioRepository> logger, SpotifyContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IEnumerable<RadioDTO>> GetAllAsync()
        {
            try
            {
                var radios = await _context.Radios
                                     .Include(r => r.OnAirPlaylist)
                                     .ThenInclude(p => p.Songs)
                                     .ToListAsync();

                if(!radios.Any())
                {
                    _logger.LogInformation("No radios found");
                    return null;
                }

                return radios.Select(r => new RadioDTO(r));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"There was an error while trying to retrieve data from Radio tables");
                throw;
            }
        }

        public async Task<RadioDTO> GetByIdAsync(int id)
        {
            try
            {
                var radio = await _context.Radios
                                     .Include(r => r.OnAirPlaylist)
                                     .ThenInclude(p => p.Songs)
                                     .FirstOrDefaultAsync(a => a.Id == id);

                if(radio == null)
                {
                    _logger.LogInformation($"No radio with id: {id}");
                    return null;
                }

                return new RadioDTO(radio);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"There was an error while trying to retrieve data from Radio tables");
                throw;
            }
        }
    }
}
