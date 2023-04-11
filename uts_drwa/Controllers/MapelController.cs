using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace uts_drwa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapelController : ControllerBase
    {
        private readonly TodoContext _context;

        public MapelController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/Mapel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mapel>>> GetMapel()
        {
          if (_context.Mapel == null)
          {
              return NotFound();
          }
            return await _context.Mapel.ToListAsync();
        }

        // GET: api/Mapel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mapel>> GetMapel(long id)
        {
          if (_context.Mapel == null)
          {
              return NotFound();
          }
            var mapel = await _context.Mapel.FindAsync(id);

            if (mapel == null)
            {
                return NotFound();
            }

            return mapel;
        }

        // POST: api/Mapel
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mapel>> PostMapel(Mapel mapel)
        {
          if (_context.Mapel == null)
          {
              return Problem("Entity set 'TodoContext.Mapel'  is null.");
          }
            _context.Mapel.Add(mapel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMapel", new { id = mapel.Id }, mapel);
        }


        private bool MapelExists(long id)
        {
            return (_context.Mapel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
