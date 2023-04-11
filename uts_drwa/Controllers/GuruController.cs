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
    public class GuruController : ControllerBase
    {
        private readonly TodoContext _context;

        public GuruController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/Guru
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Guru>>> GetTodoItems()
        {
          if (_context.TodoItems == null)
          {
              return NotFound();
          }
            return await _context.TodoItems.ToListAsync();
        }

        // GET: api/Guru/5
        [HttpGet("{nip}")]
        public async Task<ActionResult<Guru>> GetGuru(long nip)
        {
          if (_context.TodoItems == null)
          {
              return NotFound();
          }
            var guru = await _context.TodoItems.FindAsync(nip);

            if (guru == null)
            {
                return NotFound();
            }

            return guru;
        }



        // POST: api/Guru
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Guru>> PostGuru(Guru guru)
        {
          if (_context.TodoItems == null)
          {
              return Problem("Entity set 'TodoContext.TodoItems'  is null.");
          }
            _context.TodoItems.Add(guru);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetGuru", new { nip = guru.nip }, guru);
            return CreatedAtAction(nameof(GetGuru), new { nip = guru.nip }, guru);
        }


        private bool GuruExists(long nip)
        {
            return (_context.TodoItems?.Any(e => e.nip == nip)).GetValueOrDefault();
        }
    }
}
