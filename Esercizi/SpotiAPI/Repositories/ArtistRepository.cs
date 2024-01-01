using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpotiAPI.Interfaces;
using SpotiAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using SpotiAPI.Models.ModelsDTO;
using System.Linq;

namespace SpotiAPI.Repositories
{
    internal class ArtistRepository : IBasicRepository<ArtistDTO>
    {
        private readonly SpotifyContext _context;
        private readonly ILogger<ArtistRepository> _logger;

        public ArtistRepository(ILogger<ArtistRepository> logger, SpotifyContext context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<ArtistDTO>> GetAllAsync()
        {
            try
            {
                var artists = await _context.Artists
                                            .Include(a => a.Albums)
                                            .ThenInclude(album => album.Songs)
                                            .ToListAsync();
                
                var artistDTOs = artists.Select(a => new ArtistDTO(a));

                return artistDTOs;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"There was an error while trying to retrieve data from Artists tables");
                throw;
            }
        }

        public async Task<ArtistDTO> GetByIdAsync(int id)
        {
            try
            {
                var artist = await _context.Artists.FirstOrDefaultAsync(a => a.Id == id);
                var artistDTO = new ArtistDTO(artist);

                if (artistDTO == null)
                {
                    _logger.LogInformation($"No Artist with id: {id}");
                    return null;
                }

                return artistDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"There was an error while trying to retrieve data from Artists tables");
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="artists"></param>
        /// <param name="artistsAlbums"></param>
        /// <returns><c>true</c> if collections are populated, otherwise <c>false</c></returns>
        private bool CheckAlbumsAndArtistsRequest(List<Artist> artists, List<Album> artistsAlbums)
        {
            if (!artists.Any())
            {
                _logger.LogInformation("No artists found");
                return false;
            }
            else if (!artistsAlbums.Any())
            {
                _logger.LogInformation("No albums found");
                return false;
            }

            return true;
        }
        private async Task<Album> LoadAlbumsSongs(Album album)
        {
            try
            {
                album.Songs = await _context.Songs.Where(s => s.AlbumId == album.Id).ToListAsync();
                return album;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving data from Songs tables for Albums");
                throw;
            }
        }
    }
}
