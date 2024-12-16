using System.Diagnostics;
using LibraryManagement.Data;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryBranchListController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LibraryBranchListController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/LibraryBranchList
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LibraryBranch>>> GetLibraryBranches()
        {
            if (_context.LibraryBranches == null)
            {
                return NotFound();
            }
            return await _context.LibraryBranches.ToListAsync();
        }

        // GET: api/LibraryBranchList/3
        [HttpGet("{id}")]
        public async Task<ActionResult<LibraryBranch>> GetLibraryBranch(int id)
        {
            if (_context.LibraryBranches == null)
            {
                return NotFound();
            }

            var libraryBranch = await _context.LibraryBranches.FindAsync(id);

            if (libraryBranch == null)
            {
                return NotFound();
            }

            return libraryBranch;
        }

        // POST: api/LibraryBranchList
        [HttpPost]
        public async Task<ActionResult<LibraryBranch>> PostLibraryBranch(LibraryBranch libraryBranch)
        {
            if (_context.LibraryBranches == null)
            {
                return Problem("Entity set 'AppDbContext.LibraryBranches'  is null.");
            }
            _context.LibraryBranches.Add(libraryBranch);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetLibraryBranch", new { id = libraryBranch.LibraryBranchId }, libraryBranch);
            return CreatedAtAction(nameof(GetLibraryBranch), new { id = libraryBranch.LibraryBranchId }, libraryBranch);
        }

        // PUT: api/LibraryBranchList/3
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibraryBranch(int id, LibraryBranch libraryBranch)
        {
            if (id != libraryBranch.LibraryBranchId)
            {
                return BadRequest();
            }

            _context.Entry(libraryBranch).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibraryBranchExists(id))
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

        // DELETE: api/LibraryBranchList/3
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibraryBranch(int id)
        {
            if (_context.LibraryBranches == null)
            {
                return NotFound();
            }

            var libraryBranch = await _context.LibraryBranches.FindAsync(id);
            if (libraryBranch == null)
            {
                return NotFound();
            }

            _context.LibraryBranches.Remove(libraryBranch);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LibraryBranchExists(long id)
        {
            return _context.LibraryBranches.Any(e => e.LibraryBranchId == id);
        }

    }
}