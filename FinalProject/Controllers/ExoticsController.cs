using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExoticsController : ControllerBase
    {
        private readonly FinalProjectContext _context;

        public ExoticsController(FinalProjectContext context)
        {
            _context = context;
        }

        // GET: api/Exotics
        [HttpGet]
        public IEnumerable<Exotic> GetExotic()
        {
            return _context.Exotic;
        }

        // GET: api/Exotics/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExotic([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var exotic = await _context.Exotic.FindAsync(id);

            if (exotic == null)
            {
                return NotFound();
            }

            return Ok(exotic);
        }

        // PUT: api/Exotics/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExotic([FromRoute] string id, [FromBody] Exotic exotic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != exotic.Id)
            {
                return BadRequest();
            }

            _context.Entry(exotic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExoticExists(id))
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

        // POST: api/Exotics
        [HttpPost]
        public async Task<IActionResult> PostExotic([FromBody] Exotic exotic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Exotic.Add(exotic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExotic", new { id = exotic.Id }, exotic);
        }

        // DELETE: api/Exotics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExotic([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var exotic = await _context.Exotic.FindAsync(id);
            if (exotic == null)
            {
                return NotFound();
            }

            _context.Exotic.Remove(exotic);
            await _context.SaveChangesAsync();

            return Ok(exotic);
        }

        private bool ExoticExists(string id)
        {
            return _context.Exotic.Any(e => e.Id == id);
        }
    }
}