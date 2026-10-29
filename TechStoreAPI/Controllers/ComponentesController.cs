using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechStoreAPI.Data;
using TechStoreAPI.Models;

namespace TechStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ComponentesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Componentes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Componente>>> GetComponentes()
        {
            return await _context.Componentes.ToListAsync();
        }

        // POST: api/Componentes
        [HttpPost]
        public async Task<ActionResult<Componente>> PostComponente(Componente componente)
        {
            _context.Componentes.Add(componente);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetComponentes), new { id = componente.Id }, componente);
        }

        // PUT: api/Componentes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComponente(int id, Componente componente)
        {
            // Validar que el ID de la URL coincida con el ID del objeto
            if (id != componente.Id)
            {
                return BadRequest("El ID del componente no coincide.");
            }

            _context.Entry(componente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComponenteExists(id))
                {
                    return NotFound("El componente no existe.");
                }
                else
                {
                    throw;
                }
            }

            return NoContent(); // 204 No Content indica que se actualizó con éxito
        }

        // Método auxiliar para verificar si el componente existe en la BD
        private bool ComponenteExists(int id)
        {
            return _context.Componentes.Any(e => e.Id == id);
        }

        // DELETE: api/Componentes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComponente(int id)
        {
            var componente = await _context.Componentes.FindAsync(id);
            if (componente == null) return NotFound();

            _context.Componentes.Remove(componente);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}