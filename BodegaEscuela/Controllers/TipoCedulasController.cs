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
    public class TipoCedulasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TipoCedulasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TipoCedulas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoCedula>>> GetTipoCedula()
        {
            return await _context.TipoCedula.ToListAsync();
        }

        // GET: api/TipoCedulas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoCedula>> GetTipoCedula(int id)
        {
            var tipoCedula = await _context.TipoCedula.FindAsync(id);

            if (tipoCedula == null)
            {
                return NotFound();
            }

            return tipoCedula;
        }

        // PUT: api/TipoCedulas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoCedula(int id, TipoCedula tipoCedula)
        {
            if (id != tipoCedula.IdTipo)
            {
                return BadRequest();
            }

            _context.Entry(tipoCedula).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoCedulaExists(id))
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

        // POST: api/TipoCedulas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoCedula>> PostTipoCedula(TipoCedula tipoCedula)
        {
            _context.TipoCedula.Add(tipoCedula);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoCedula", new { id = tipoCedula.IdTipo }, tipoCedula);
        }

        // DELETE: api/TipoCedulas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoCedula(int id)
        {
            var tipoCedula = await _context.TipoCedula.FindAsync(id);
            if (tipoCedula == null)
            {
                return NotFound();
            }

            _context.TipoCedula.Remove(tipoCedula);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoCedulaExists(int id)
        {
            return _context.TipoCedula.Any(e => e.IdTipo == id);
        }
    }
}
