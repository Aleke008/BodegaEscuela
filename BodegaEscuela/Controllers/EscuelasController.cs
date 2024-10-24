using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BodegaEscuela.Context;
using BodegaEscuela.ModelsBE;

namespace BodegaEscuela.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EscuelasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EscuelasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Escuelas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Escuela>>> GetEscuelas()
        {
            return await _context.Escuelas.ToListAsync();
        }

        // GET: api/Escuelas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Escuela>> GetEscuela(int id)
        {
            var escuela = await _context.Escuelas.FindAsync(id);

            if (escuela == null)
            {
                return NotFound();
            }

            return escuela;
        }

        // PUT: api/Escuelas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEscuela(int id, Escuela escuela)
        {
            if (id != escuela.IdEscuela)
            {
                return BadRequest();
            }

            _context.Entry(escuela).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EscuelaExists(id))
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

        // POST: api/Escuelas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Escuela>> PostEscuela(Escuela escuela)
        {
            _context.Escuelas.Add(escuela);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEscuela", new { id = escuela.IdEscuela }, escuela);
        }

        // DELETE: api/Escuelas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEscuela(int id)
        {
            var escuela = await _context.Escuelas.FindAsync(id);
            if (escuela == null)
            {
                return NotFound();
            }

            _context.Escuelas.Remove(escuela);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EscuelaExists(int id)
        {
            return _context.Escuelas.Any(e => e.IdEscuela == id);
        }
    }
}
