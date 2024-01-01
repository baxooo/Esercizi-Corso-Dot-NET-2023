using Microsoft.AspNetCore.Http;
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
    [Route("/api/Spotify/Radio")]
    public class RadioController : Controller
    {
        private readonly ILogger<RadioController> _logger;
        private readonly IBasicRepository<RadioDTO> _radioRepo;

        public RadioController(ILogger<RadioController> logger, IBasicRepository<RadioDTO> radioRepo)
        {
            _logger = logger;
            _radioRepo = radioRepo;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RadioDTO>> GetById(int id)
        {
            var albumResult = await _radioRepo.GetByIdAsync(id);

            if (albumResult == null)
                return NotFound();

            return Ok(albumResult);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RadioDTO>>> GetAll()
        {
            _logger.LogInformation($"Request for Fecthing all user's radios");
            var result = await _radioRepo.GetAllAsync();
            if (result == null || !result.Any())
                return NotFound();

            return Ok(result);
        }
    }
}
