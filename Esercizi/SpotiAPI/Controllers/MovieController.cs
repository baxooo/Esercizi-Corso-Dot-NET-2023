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
    [Route("/api/Spotify/Movie")]
    public class MovieController : Controller
    {
        private readonly ILogger<MovieController> _logger;
        private readonly IBasicRepository<MovieDTO> _MovieRepo;

        public MovieController(ILogger<MovieController> logger, IBasicRepository<MovieDTO> songRepo)
        {
            _logger = logger;
            _MovieRepo = songRepo;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDTO>> GetById(int id)
        {
            var albumResult = await _MovieRepo.GetByIdAsync(id);

            if (albumResult == null)
                return NotFound();

            return Ok(albumResult);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetAll()
        {
            _logger.LogInformation($"Request for Fecthing all user's movies");
            var result = await _MovieRepo.GetAllAsync();
            if (result == null || !result.Any())
                return NotFound();

            return Ok(result);
        }
    }
}

