using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EinkaufslistenApp.Data;
using EinkaufslistenApp.Models;

namespace EinkaufslistenApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EinkaufsItemsController : ControllerBase
    {
        private readonly EinkaufslistenDbContext _context;

        public EinkaufsItemsController(EinkaufslistenDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EinkaufsItem>>> GetEinkaufsItems()
        {
            return await _context.EinkaufsItems.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EinkaufsItem>> GetEinkaufsItem(int id)
        {
            var item = await _context.EinkaufsItems.FindAsync(id);
            if (item == null)
                return NotFound();

            return item;
        }

        [HttpGet("benutzer/{benutzerId}")]
        public async Task<ActionResult<IEnumerable<EinkaufsItem>>> GetEinkaufsItemsByBenutzer(int benutzerId)
        {
            var items = await _context.EinkaufsItems.Where(i => i.BenutzerId == benutzerId).ToListAsync();

            if (!items.Any())
                return NotFound("Keine Einkaufsitems für diesen Benutzer gefunden.");

            return Ok(items);
        }

        [HttpPost]
        public async Task<ActionResult<EinkaufsItem>> PostEinkaufsItem(EinkaufsItem item)
        {
            if (item.BenutzerId == null)
                return BadRequest("BenutzerId ist erforderlich.");

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var benutzer = await _context.Benutzer.FindAsync(item.BenutzerId);
                    if (benutzer == null)
                        return NotFound("Benutzer existiert nicht.");

                    item.Benutzer = benutzer;  
                    _context.EinkaufsItems.Add(item);
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();  
                    return CreatedAtAction(nameof(GetEinkaufsItem), new { id = item.Id }, item);
                }
                catch
                {
                    await transaction.RollbackAsync(); 
                    return StatusCode(500, "Ein Fehler ist aufgetreten.");
                }
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEinkaufsItem(int id, EinkaufsItem item)
        {
            if (id != item.Id)
                return BadRequest();

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    _context.Entry(item).Property("RowVersion").OriginalValue = item.RowVersion;
                    _context.Entry(item).State = EntityState.Modified;

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();  

                    return NoContent();
                }
                catch (DbUpdateConcurrencyException)
                {
                    await transaction.RollbackAsync();  
                    return Conflict("Daten wurden bereits von einem anderen Benutzer geändert.");
                }
                catch
                {
                    await transaction.RollbackAsync(); 
                    return StatusCode(500, "Ein Fehler ist aufgetreten.");
                }
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEinkaufsItem(int id)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var item = await _context.EinkaufsItems.FindAsync(id);
                    if (item == null)
                        return NotFound();

                    _context.EinkaufsItems.Remove(item);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();  

                    return NoContent();
                }
                catch
                {
                    await transaction.RollbackAsync();  
                    return StatusCode(500, "Ein Fehler ist aufgetreten.");
                }
            }
        }

    }
}
