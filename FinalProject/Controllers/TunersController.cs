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
    public class TunersController : ControllerBase
    {
        private readonly FinalProjectContext _context;

        public TunersController(FinalProjectContext context)
        {
            _context = context;
        }

        // GET: api/Tuners
        [HttpGet]
        public IEnumerable<Tuner> GetTuner()
        {
            return _context.Tuner;
        }

        // GET: api/Tuners/5
       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTuner([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tuner = await _context.Tuner.FindAsync(id);

            if (tuner == null)
            {
                return NotFound();
            }

            return Ok(tuner);
        }

        // PUT: api/Tuners/5.
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTuner([FromRoute] string id, [FromBody] Tuner tuner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tuner.Id)
            {
                return BadRequest();
            }

            _context.Entry(tuner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TunerExists(id))
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

        // POST: api/Tuners
        
        [HttpPost]
        public async Task<IActionResult> PostTuner([FromBody] Tuner tuner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Tuner.Add(tuner);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTuner", new { id = tuner.Id }, tuner);
        }

        // DELETE: api/Tuners/5
       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTuner([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tuner = await _context.Tuner.FindAsync(id);
            if (tuner == null)
            {
                return NotFound();
            }

            _context.Tuner.Remove(tuner);
            await _context.SaveChangesAsync();

            return Ok(tuner);
        }

        private bool TunerExists(string id)
        {
            return _context.Tuner.Any(e => e.Id == id);
        }
    }
}