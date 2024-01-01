using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpotiAPI.Interfaces;
using SpotiAPI.Models.ModelsDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpotiAPI.Controllers
{
    [ApiController]
    [Route("/api/Spotify/Artist")]
    public class ArtistController : Controller
    {
        private readonly ILogger<ArtistController> _logger;
        private readonly IBasicRepository<ArtistDTO> _artistRepo;

        public ArtistController(ILogger<ArtistController> logger, IBasicRepository<ArtistDTO> albumRepo)
        {
            _logger = logger;
            _artistRepo = albumRepo;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ArtistDTO>> GetById(int id)
        {
            var result = await _artistRepo.GetByIdAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IEnumerable<ArtistDTO>> GetAll()
        {
            _logger.LogInformation($"Request for Fecthing all user's arists");
            var result = await _artistRepo.GetAllAsync();

            return result;
        }
    }
}
