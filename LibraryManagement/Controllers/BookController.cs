// BookController.cs
using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Models;
using LibraryManagement.Data;

namespace LibraryManagement.Controllers
{
    public class BookController : Controller
    {
        private readonly AppDbContext _dbContext;

        public BookController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var books = _dbContext.Books.ToList();
            return View(books);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Book/Update/<bookId>
        public IActionResult Update(int id)
        {
            var book = _dbContext.Books.FirstOrDefault(b => b.BookId == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);

        }

        // POST: Book/Update/<bookId>
        [HttpPost]
        public IActionResult Update(Book book)
        {
            var existingBook = _dbContext.Books.FirstOrDefault(b => b.BookId == book.BookId);
            if (existingBook == null)
            {
                return NotFound();
            }

            //existingBook.BookId = book.BookId;
            existingBook.Title = book.Title;
            existingBook.AuthorId = book.AuthorId;
            existingBook.LibraryBranchId = book.LibraryBranchId;

            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Book/Delete/<bookId>
        public IActionResult Delete(int id)
        {
            var book = _dbContext.Books.FirstOrDefault(b => b.BookId == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Book/Delete/<bookId>
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var book = _dbContext.Books.FirstOrDefault(b => b.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
