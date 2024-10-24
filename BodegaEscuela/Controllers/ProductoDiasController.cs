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
    public class ProductoDiasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductoDiasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductoDias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoDia>>> GetProductoDias()
        {
            return await _context.ProductoDias.ToListAsync();
        }

        // GET: api/ProductoDias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDia>> GetProductoDia(int id)
        {
            var productoDia = await _context.ProductoDias.FindAsync(id);

            if (productoDia == null)
            {
                return NotFound();
            }

            return productoDia;
        }

        // PUT: api/ProductoDias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductoDia(int id, ProductoDia productoDia)
        {
            if (id != productoDia.IdProductoDia)
            {
                return BadRequest();
            }

            _context.Entry(productoDia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoDiaExists(id))
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

        // POST: api/ProductoDias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductoDia>> PostProductoDia(ProductoDia productoDia)
        {
            _context.ProductoDias.Add(productoDia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductoDia", new { id = productoDia.IdProductoDia }, productoDia);
        }

        // DELETE: api/ProductoDias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductoDia(int id)
        {
            var productoDia = await _context.ProductoDias.FindAsync(id);
            if (productoDia == null)
            {
                return NotFound();
            }

            _context.ProductoDias.Remove(productoDia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductoDiaExists(int id)
        {
            return _context.ProductoDias.Any(e => e.IdProductoDia == id);
        }
    }
}
