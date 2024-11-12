// CustomerController.cs
using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Models;
using LibraryManagement.Data;

namespace LibraryManagement.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AppDbContext _dbContext;

        public CustomerController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var customers = _dbContext.Customers.ToList();
            return View(customers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Customer/Update/<CustomerId>
        public IActionResult Update(int id)
        {
            var customer = _dbContext.Customers.FirstOrDefault(c => c.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);

        }

        // POST: Customer/Update/<CustomerId>
        [HttpPost]
        public IActionResult Update(Customer customer)
        {
            var existingCustomer = _dbContext.Customers.FirstOrDefault(c => c.CustomerId == customer.CustomerId);
            if (existingCustomer == null)
            {
                return NotFound();
            }

            existingCustomer.CustomerId = customer.CustomerId;
            existingCustomer.Name = customer.Name;


            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Customer/Delete/<CustomerId>
        public IActionResult Delete(int id)
        {
            var customer = _dbContext.Customers.FirstOrDefault(c => c.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customer/Delete/<CustomerId>
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var customer = _dbContext.Customers.FirstOrDefault(c => c.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            _dbContext.Customers.Remove(customer);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
