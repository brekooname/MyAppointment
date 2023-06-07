using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using MyAppointment.Data;
using MyAppointment.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppointment.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PartsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Part> GetPart()
        {
            return _context.Parts;
        }

        //Get
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPart([FromRoute] int id, [FromBody] Part part)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != part.Id)
            {
                return BadRequest();
            }

            _context.Entry(part).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartExists(id))
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

        //Post
        [HttpPost]
        public async Task<IActionResult> PostPart([FromBody] Part part)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Parts.Add(part);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPart", new { id = part.Id }, part);

        }

        //Delete
        [HttpPost("{id}")]
        public async Task<IActionResult> DeletePart([FromRoute] int id)
        {
            if(!ModelState.IsValid)
             {
                return BadRequest(ModelState);
             }
            var part = await _context.Parts.FindAsync(id);
            if (part == null)
            {
                return NotFound();
            }

            _context.Parts.Remove(part);
            await _context.SaveChangesAsync();
            return Ok(part);
        }

        private bool PartExists(int id)
        {
            return _context.Parts.Any(e => e.Id == id);
        }

    }
}
