using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpotiAPI.Interfaces;
using SpotiAPI.Models.ModelsDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpotiAPI.Controllers
{
    [ApiController]
    [Route("/api/Spotify/Album")]
    public class AlbumController : Controller
    {
        private readonly ILogger<AlbumController> _logger;
        private readonly IBasicRepository<AlbumDTO> _albumRepo;

        public AlbumController(ILogger<AlbumController> logger, IBasicRepository<AlbumDTO> albumRepo)
        {
            _logger = logger;
            _albumRepo = albumRepo;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AlbumDTO>> GetById(int id)
        {
            var albumResult = await _albumRepo.GetByIdAsync(id);

            if (albumResult == null)
                return NotFound();

            return Ok(albumResult);
        }

        [HttpGet]
        public async Task<IEnumerable<AlbumDTO>> GetAll()
        {
            _logger.LogInformation($"Request for Fecthing all user's album");
            var result = await _albumRepo.GetAllAsync();

            return result;
        }
    }
}
