using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpensesManagingApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/examples")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        private readonly ExampleContext _context;

        public ExampleController(ExampleContext context)
        {
            _context = context;

            if (_context.ExampleItems.Count() == 0)
            {
                // Create a new ExampleItem if collection is empty,
                // which means you can't delete all ExampleItems.
                _context.ExampleItems.Add(new ExampleItem { name = "Item1" });
                _context.SaveChanges();
            }
        }
        // GET: api/examples/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExampleItem>> GetExampleItem(long id)
        {
            var ExampleItem = await _context.ExampleItems.FindAsync(id);

            if (ExampleItem == null)
            {
                return NotFound();
            }

            return ExampleItem;
        }

        [HttpPost]
        public async Task<ActionResult<ExampleItem>> PostExampleItem(ExampleItem item)
        {
            _context.ExampleItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetExampleItem), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutExampleItem(long id, ExampleItem item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExampleItem(long id)
        {
            var ExampleItem = await _context.ExampleItems.FindAsync(id);

            if (ExampleItem == null)
            {
                return NotFound();
            }

            _context.ExampleItems.Remove(ExampleItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}