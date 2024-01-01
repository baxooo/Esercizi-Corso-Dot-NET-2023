using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpotiAPI.Interfaces;
using SpotiAPI.Models.ModelsDTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotiAPI.Controllers
{
    [ApiController]
    [Route("/api/Spotify/Song")]
    public class SongController : Controller
    {
        private readonly ILogger<SongController> _logger;
        private readonly IBasicRepository<SongDTO> _songRepo;

        public SongController(ILogger<SongController> logger, IBasicRepository<SongDTO> songRepo)
        {
            _logger = logger;
            _songRepo = songRepo;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SongDTO>> GetById(int id)
        {
            var albumResult = await _songRepo.GetByIdAsync(id);

            if (albumResult == null)
                return NotFound();

            return Ok(albumResult);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SongDTO>>> GetAll()
        {
            _logger.LogInformation($"Request for Fecthing all user's songs");
            var result = await _songRepo.GetAllAsync();
            if (result == null || !result.Any())
                return NotFound();

            return Ok(result);
        }
    }
}
