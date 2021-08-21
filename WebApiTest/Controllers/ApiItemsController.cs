using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiTest.Entities;
using WebApiTest.Entities.Attributes;
using WebApiTest.Services;

namespace WebApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiItemsController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public ApiItemsController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/ApiItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApiItem>>> GetAspirantes()
        {
            return await _context.Aspirantes.ToListAsync();
        }

        // GET: api/ApiItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiItem>> GetApiItem(int id)
        {
            var apiItem = await _context.Aspirantes.FindAsync(id);

            if (apiItem == null)
            {
                return NotFound();
            }

            return apiItem;
        }

        // PUT: api/ApiItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApiItem(int id, ApiItem apiItem)
        {
            if (id != apiItem.id || !ApiItemExists(apiItem.casaestudio))
            {
                return BadRequest();
            }

            _context.Entry(apiItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApiItemExists(id))
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

        // POST: api/ApiItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ApiItem>> PostApiItem(ApiItem apiItem)
        {
            
            if (!ApiItemExists(apiItem.casaestudio) || apiItem.nombre.Length > 20 || apiItem.apellido.Length > 20
                || apiItem.identificacion.ToString().Length > 10 || apiItem.identificacion.ToString().Length > 3
                )
            {
                return BadRequest();
            }
            else
            {
                _context.Aspirantes.Add(apiItem);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetApiItem", new { id = apiItem.id }, apiItem);
            }
        }

        private bool ApiItemExists(ApiCasaEstudio casaestudio)
        {
            return Enum.IsDefined(typeof(ApiCasaEstudio), casaestudio);
        }

        // DELETE: api/ApiItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApiItem(int id)
        {
            var apiItem = await _context.Aspirantes.FindAsync(id);
            if (apiItem == null)
            {
                return NotFound();
            }

            _context.Aspirantes.Remove(apiItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ApiItemExists(int id)
        {
            return _context.Aspirantes.Any(e => e.id == id);
        }
    }
}
