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
    public class AuthController : ControllerBase
    {
        private readonly DBcontext _context;

        public AuthController(DBcontext context)
        {
            _context = context;
        }

        // GET: api/Auth
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Auths>>> GetAllauths()
        {
          if (_context.Allauths == null)
          {
              return NotFound();
          }
            return await _context.Allauths.ToListAsync();
        }

        // GET: api/Auth/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Auths>> GetAuths(int id)
        {
          if (_context.Allauths == null)
          {
              return NotFound();
          }
            var auths = await _context.Allauths.FindAsync(id);

            if (auths == null)
            {
                return NotFound();
            }

            return auths;
        }

        // PUT: api/Auth/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuths(int id, Auths auths)
        {
            if (id != auths.Id)
            {
                return BadRequest();
            }

            _context.Entry(auths).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthsExists(id))
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

        // POST: api/Auth
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Auths>> PostAuths(Auths auths)
        {
          if (_context.Allauths == null)
          {
              return Problem("Entity set 'DBcontext.Allauths'  is null.");
          }
            _context.Allauths.Add(auths);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuths", new { id = auths.Id }, auths);
        }

        // DELETE: api/Auth/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuths(int id)
        {
            if (_context.Allauths == null)
            {
                return NotFound();
            }
            var auths = await _context.Allauths.FindAsync(id);
            if (auths == null)
            {
                return NotFound();
            }

            _context.Allauths.Remove(auths);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AuthsExists(int id)
        {
            return (_context.Allauths?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
