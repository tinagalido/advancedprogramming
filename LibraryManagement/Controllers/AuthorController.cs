// AuthorController.cs
using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Models;
using LibraryManagement.Data;

namespace LibraryManagement.Controllers
{
    public class AuthorController : Controller
    {
        private readonly AppDbContext _dbContext;

        public AuthorController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var authors = _dbContext.Authors.ToList();
            return View(authors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Author author)
        {
            _dbContext.Authors.Add(author);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Author/Update/<authorId>
        public IActionResult Update(int id)
        {
            var author = _dbContext.Authors.FirstOrDefault(a => a.AuthorId == id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);

        }

        // POST: Author/Update/<authorId>
        [HttpPost]
        public IActionResult Update(Author author)
        {
            var existingAuthor = _dbContext.Authors.FirstOrDefault(a => a.AuthorId == author.AuthorId);
            if (existingAuthor == null)
            {
                return NotFound();
            }

            existingAuthor.AuthorId = author.AuthorId;
            existingAuthor.Name = author.Name;


            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Author/Delete/<authorId>
        public IActionResult Delete(int id)
        {
            var author = _dbContext.Authors.FirstOrDefault(a => a.AuthorId == id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        // POST: Author/Delete/<authorId>
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var author = _dbContext.Authors.FirstOrDefault(a => a.AuthorId == id);
            if (author == null)
            {
                return NotFound();
            }

            _dbContext.Authors.Remove(author);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
