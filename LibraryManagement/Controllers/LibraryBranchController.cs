// LibraryBranchController.cs
using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Models;
using LibraryManagement.Data;

namespace LibraryManagement.Controllers
{
    public class LibraryBranchController : Controller
    {
        private readonly AppDbContext _dbContext;

        public LibraryBranchController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var libraryBranches = _dbContext.LibraryBranches.ToList();
            return View(libraryBranches);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(LibraryBranch libraryBranch)
        {
            _dbContext.LibraryBranches.Add(libraryBranch);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: LibraryBranch/Update/<LibraryBranchId>
        public IActionResult Update(int id)
        {
            var libraryBranch = _dbContext.LibraryBranches.FirstOrDefault(l => l.LibraryBranchId == id);
            if (libraryBranch == null)
            {
                return NotFound();
            }
            return View(libraryBranch);

        }

        // POST: LibraryBranch/Update/<LibraryBranchId>
        [HttpPost]
        public IActionResult Update(LibraryBranch libraryBranch)
        {
            var existingLibraryBranch = _dbContext.LibraryBranches.FirstOrDefault(l => l.LibraryBranchId == libraryBranch.LibraryBranchId);
            if (existingLibraryBranch == null)
            {
                return NotFound();
            }

            existingLibraryBranch.LibraryBranchId = libraryBranch.LibraryBranchId;
            existingLibraryBranch.BranchName = libraryBranch.BranchName;


            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: LibraryBranch/Delete/<LibraryBranchId>
        public IActionResult Delete(int id)
        {
            var libraryBranch = _dbContext.LibraryBranches.FirstOrDefault(l => l.LibraryBranchId == id);
            if (libraryBranch == null)
            {
                return NotFound();
            }
            return View(libraryBranch);
        }

        // POST: LibraryBranch/Delete/<LibraryBranchId>
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var libraryBranch = _dbContext.LibraryBranches.FirstOrDefault(l => l.LibraryBranchId == id);
            if (libraryBranch == null)
            {
                return NotFound();
            }

            _dbContext.LibraryBranches.Remove(libraryBranch);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
