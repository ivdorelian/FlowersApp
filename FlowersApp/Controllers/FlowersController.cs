using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FlowersApp.Models;
using FlowersApp.ViewModels;

namespace FlowersApp.Controllers
{


    // TODO: make CRUD comments work with URL api/Flowers/{id}/Comments
    // TODO: make CRUD comments with another comments controller: api/comments/{flower id}
    // TODO: write a validator for comments

    [Route("api/[controller]")]
    [ApiController]
    public class FlowersController : ControllerBase
    {
        private readonly FlowersDbContext _context;

        public FlowersController(FlowersDbContext context)
        {
            _context = context;
        }

        // GET: api/Flowers, read more about swagger: https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-3.1&tabs=visual-studio
        /// <summary>
        /// Gets a list of all the flowers. 
        /// </summary>
        /// <param name="from">Filter flowers added from this date time (inclusive). Leave empty for no lower limit.</param>
        /// <param name="to">Filter flowers add up to this date time (inclusive). Leave empty for no upper limit.</param>
        /// <returns>A list of Flower objects.</returns>       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlowerWithNumberOfComments>>> GetFlowers(
            [FromQuery]DateTimeOffset? from = null,
            [FromQuery]DateTimeOffset? to = null)
        {
            var identity = User.Identity;

            IQueryable<Flower> result = _context.Flowers;
            if (from != null)
            {
                result = result.Where(f => from <= f.DateAdded);
            }
            if (to != null)
            {
                result = result.Where(f => f.DateAdded <= to);
            }

            var resultList = await result
                .OrderByDescending(f => f.MarketPrice)
                .Include(f => f.Comments)
                .Select(f => FlowerWithNumberOfComments.FromFlower(f))
                .ToListAsync();
            return resultList;
        }

        // GET: api/Flowers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FlowerDetails>> GetFlower(long id)
        {
            var flower = await _context
                .Flowers
                .Include(f => f.Comments)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (flower == null)
            {
                return NotFound();
            }

            return FlowerDetails.FromFlower(flower);
        }

        // PUT: api/Flowers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlower(long id, Flower flower)
        {
            if (id != flower.Id)
            {
                return BadRequest();
            }

            _context.Entry(flower).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlowerExists(id))
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

        // POST: api/Flowers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Flower>> PostFlower(Flower flower)
        {
            _context.Flowers.Add(flower);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFlower", new { id = flower.Id }, flower);
        }

        // DELETE: api/Flowers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Flower>> DeleteFlower(long id)
        {
            var flower = await _context.Flowers.FindAsync(id);
            if (flower == null)
            {
                return NotFound();
            }

            _context.Flowers.Remove(flower);
            await _context.SaveChangesAsync();

            return flower;
        }

        private bool FlowerExists(long id)
        {
            return _context.Flowers.Any(e => e.Id == id);
        }
    }
}
