using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelsAPI.Models;

namespace TravelsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelsController : ControllerBase
    {
        private readonly TravelDBContext _context;

        public TravelsController(TravelDBContext context)
        {
            _context = context;
        }

        // GET: api/Travels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Travels>>> GetTravels()
        {
            return await _context.TravelDetails.ToListAsync();
        }

        // GET: api/Travels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Travels>> GetTravels(int id)
        {
            var travels = await _context.Travels.FindAsync(id);

            if (travels == null)
            {
                return NotFound();
            }

            return travelDetail;
        }

        // PUT: api/Travels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTravels(int id, Travels travelDetail)
        {
            if (id != travels.Id)
            {
                return BadRequest();
            }

            _context.Entry(travels).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TravelsExists(id))
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

        // POST: api/Travels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Travels>> PostTravels(Travels travels)
        {
            _context.Travels.Add(travels);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTravels", new { id = travels.Id }, travels);
        }

        // DELETE: api/Travels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTravels(int id)
        {
            var travels = await _context.Travels.FindAsync(id);
            if (travels == null)
            {
                return NotFound();
            }

            _context.Travels.Remove(travels);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TravelsExists(int id)
        {
            return _context.Travels.Any(e => e.Id == id);
        }
    }
}
