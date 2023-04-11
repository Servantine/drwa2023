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
    public class JadwalGuruController : ControllerBase
    {
        private readonly TodoContext _context;

        public JadwalGuruController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/JadwalGuru
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JadwalGuru>>> GetJadwalGuru()
        {
          if (_context.JadwalGuru == null)
          {
              return NotFound();
          }
            return await _context.JadwalGuru.ToListAsync();
        }

        // GET: api/JadwalGuru/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JadwalGuru>> GetJadwalGuru(long id)
        {
          if (_context.JadwalGuru == null)
          {
              return NotFound();
          }
            var jadwalGuru = await _context.JadwalGuru.FindAsync(id);

            if (jadwalGuru == null)
            {
                return NotFound();
            }

            return jadwalGuru;
        }


        // POST: api/JadwalGuru
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JadwalGuru>> PostJadwalGuru(JadwalGuru jadwalGuru)
        {
          if (_context.JadwalGuru == null)
          {
              return Problem("Entity set 'TodoContext.JadwalGuru'  is null.");
          }
            _context.JadwalGuru.Add(jadwalGuru);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJadwalGuru", new { id = jadwalGuru.Id }, jadwalGuru);
        }
        
                // GET: api/JadwalGuru/5
        [HttpGet("{nip}")]
        public async Task<ActionResult<JadwalGuru>> GetGuru(long nip)
        {
          if (_context.JadwalGuru == null)
          {
              return NotFound();
          }
          //  var jadwalGuru = await _context.TodoItems.FindAsync(nip);

         //   if (jadwalGuru == null)
        //    {
         //       return NotFound();
         //   }

            return NotFound();
        }

        [HttpGet("{id_mapel}")]
        public async Task<ActionResult<JadwalGuru>> GetMapel(long nip)
        {
          if (_context.JadwalGuru == null)
          {
              return NotFound();
          }
          //  var jadwalGuru = await _context.TodoItems.FindAsync(nip);

         //   if (jadwalGuru == null)
        //    {
         //       return NotFound();
         //   }

            return NotFound();
        }


        private bool JadwalGuruExists(long id)
        {
            return (_context.JadwalGuru?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
