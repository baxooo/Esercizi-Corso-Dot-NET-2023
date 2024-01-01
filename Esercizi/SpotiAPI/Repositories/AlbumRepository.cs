using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpotiAPI.Interfaces;
using SpotiAPI.Models;
using SpotiAPI.Models.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotiAPI.Repositories
{
    internal class AlbumRepository : IBasicRepository<AlbumDTO>
    {
        private readonly ILogger<AlbumRepository> _logger;
        private readonly SpotifyContext _context;
        public AlbumRepository(SpotifyContext context, ILogger<AlbumRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<AlbumDTO>> GetAllAsync()
        {
            try
            {
                var albums = await _context.Albums
                                           .Include(a => a.Songs)
                                           .ToListAsync();

                if(!albums.Any())
                {
                    _logger.LogInformation("No albums found");
                    return null;
                }

                return albums.Select(a => new AlbumDTO(a));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving data from Album tables");
                throw;
            }
        }

        public async Task<AlbumDTO> GetByIdAsync(int id)
        {
            try
            {
                var album = await _context.Albums
                                          .Include(a => a.Songs)
                                          .FirstOrDefaultAsync(a => a.Id == id);

                if(album == null)
                {
                    _logger.LogInformation($"No Album with id: {id}");
                    return null;
                }

                return new AlbumDTO(album);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"There was an error while trying to retrieve data from Album tables");
                throw;
            }
        }
    }
}
