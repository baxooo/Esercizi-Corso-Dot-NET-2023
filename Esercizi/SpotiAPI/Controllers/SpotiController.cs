using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpotiAPI.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotiAPI.Controllers
{
    [ApiController]
    [Route("/api/Spotify")]
    public class SpotiController : Controller
    {
        private readonly SpotifyContext _context;
        public SpotiController(SpotifyContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Song>> GetSong(int id)
        {
            var result = await _context.Songs.FirstOrDefaultAsync(s => s.Id == id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpGet]
        public async Task<IEnumerable<Song>> GetSong()
        {
            var result = await _context.Songs.ToListAsync();

            return result;
        }
    }
}
