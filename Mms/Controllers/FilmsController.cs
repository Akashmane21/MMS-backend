using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mms.Model;

namespace Mms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly DBcontext _context;

        public FilmsController(DBcontext context)
        {
            _context = context;
        }

        // GET: api/Films
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Films>>> GetAllfilms()
        {
          if (_context.Allfilms == null)
          {
              return NotFound();
          }
            return await _context.Allfilms.ToListAsync();
        }

        // GET: api/Films/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Films>> GetFilms(int id)
        {
          if (_context.Allfilms == null)
          {
              return NotFound();
          }
            var films = await _context.Allfilms.FindAsync(id);

            if (films == null)
            {
                return NotFound();
            }

            return films;
        }

        // PUT: api/Films/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilms(int id, Films films)
        {
            if (id != films.Id)
            {
                return BadRequest();
            }

            _context.Entry(films).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Films
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Films>> PostFilms(Films films)
        {
          if (_context.Allfilms == null)
          {
              return Problem("Entity set 'DBcontext.Allfilms'  is null.");
          }
            _context.Allfilms.Add(films);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFilms", new { id = films.Id }, films);
        }

        // DELETE: api/Films/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilms(int id)
        {
            if (_context.Allfilms == null)
            {
                return NotFound();
            }
            var films = await _context.Allfilms.FindAsync(id);
            if (films == null)
            {
                return NotFound();
            }

            _context.Allfilms.Remove(films);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FilmsExists(int id)
        {
            return (_context.Allfilms?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
