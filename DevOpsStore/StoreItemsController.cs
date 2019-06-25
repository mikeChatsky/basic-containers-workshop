using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevOpsStore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DevOpsStore.Models;

namespace DevOpsStore
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreItemsController : ControllerBase
    {
        private readonly DevOpsStoreContext _context;

        public StoreItemsController(DevOpsStoreContext context)
        {
            _context = context;
        }

        // GET: api/StoreItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoreItem>>> GetStoreItem()
        {
            return await _context.StoreItem.ToListAsync();
        }

        // GET: api/StoreItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StoreItem>> GetStoreItem(string id)
        {
            var storeItem = await _context.StoreItem.FindAsync(id);

            if (storeItem == null)
            {
                return NotFound();
            }

            return storeItem;
        }

        // PUT: api/StoreItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStoreItem(string id, StoreItem storeItem)
        {
            if (id != storeItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(storeItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoreItemExists(id))
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

        // POST: api/StoreItems
        [HttpPost]
        public async Task<ActionResult<StoreItem>> PostStoreItem(StoreItem storeItem)
        {
            _context.StoreItem.Add(storeItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStoreItem", new { id = storeItem.Id }, storeItem);
        }

        // DELETE: api/StoreItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StoreItem>> DeleteStoreItem(string id)
        {
            var storeItem = await _context.StoreItem.FindAsync(id);
            if (storeItem == null)
            {
                return NotFound();
            }

            _context.StoreItem.Remove(storeItem);
            await _context.SaveChangesAsync();

            return storeItem;
        }

        private bool StoreItemExists(string id)
        {
            return _context.StoreItem.Any(e => e.Id == id);
        }
    }
}
