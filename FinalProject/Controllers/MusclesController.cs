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
    public class MusclesController : ControllerBase
    {
        private readonly FinalProjectContext _context;

        public MusclesController(FinalProjectContext context)
        {
            _context = context;
        }

        // GET: api/Muscles
        [HttpGet]
        public IEnumerable<Muscle> GetMuscle()
        {
            return _context.Muscle;
        }

        // GET: api/Muscles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMuscle([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var muscle = await _context.Muscle.FindAsync(id);

            if (muscle == null)
            {
                return NotFound();
            }

            return Ok(muscle);
        }

        // PUT: api/Muscles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMuscle([FromRoute] string id, [FromBody] Muscle muscle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != muscle.Id)
            {
                return BadRequest();
            }

            _context.Entry(muscle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MuscleExists(id))
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

        // POST: api/Muscles
        [HttpPost]
        public async Task<IActionResult> PostMuscle([FromBody] Muscle muscle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Muscle.Add(muscle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMuscle", new { id = muscle.Id }, muscle);
        }

        // DELETE: api/Muscles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMuscle([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var muscle = await _context.Muscle.FindAsync(id);
            if (muscle == null)
            {
                return NotFound();
            }

            _context.Muscle.Remove(muscle);
            await _context.SaveChangesAsync();

            return Ok(muscle);
        }

        private bool MuscleExists(string id)
        {
            return _context.Muscle.Any(e => e.Id == id);
        }
    }
}